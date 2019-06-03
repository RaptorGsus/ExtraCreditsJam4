using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePlug : MonoBehaviour
{
    private bool grabbed = false;
    private bool inSocket = false;
    private bool closeToSocket = false;

    [SerializeField]
    private SocketFemale InteractingSocket;
    private Vector3 previousPosition;

    public Transform anchor;

    [Header("Sprites")]
    public SpriteRenderer defaultSprite;
    public SpriteRenderer pluggedInSprite;

    [Header("Sounds")]
    public AudioClip plugInSound;
    public AudioClip unplugSound;

    
    

    private void Start()
    {
        if (InteractingSocket != null) {
            PlugIn();
        }
    }


    private void OnMouseDown()
    {
        if (inSocket) {
            Unplug();
        }

        if (!grabbed) {
            Grab();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed) {

            //Right mouse lets go
            if (Input.GetMouseButtonDown(1)) {
                grabbed = false;
                Dangle(true);
            }

            //Left Mouse plugs in;
            if (Input.GetMouseButtonDown(0) && closeToSocket && !InteractingSocket.IsFilled()) {
                PlugIn();
            }

            //Follow the mouse
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            GetComponent<Rigidbody2D>().MovePosition(newPos);

            //Move point towards movement direction
            if (!closeToSocket && GetVelocity().magnitude > 0.02) {
                var v = GetVelocity();
                float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + 90, Vector3.forward), 20 * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        closeToSocket = true;
        if (!inSocket && grabbed) {
            InteractingSocket = collision.GetComponent<SocketFemale>();
            var dir = (collision.gameObject.transform.position - transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        closeToSocket = false;
        InteractingSocket = null;
    }

    private void LateUpdate()
    {
        previousPosition = transform.position;
    }

    private Vector3 GetVelocity()
    {
        return (previousPosition - transform.position);
    }

    

    public void Grab()
    {
        grabbed = true;
        Dangle(false);
    }

    public void PlugIn()
    {
        GetComponent<AudioSource>().PlayOneShot(plugInSound);

        grabbed = false;
        inSocket = true;
        InteractingSocket.PlugIn(this);
        transform.rotation = Quaternion.identity;
        transform.position = InteractingSocket.transform.position - anchor.localPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        pluggedInSprite.gameObject.SetActive(true);
        defaultSprite.gameObject.SetActive(false);
        Dangle(false);
    }

    private void Unplug()
    {
        GetComponent<AudioSource>().PlayOneShot(unplugSound);
        InteractingSocket.Unplug();
        inSocket = false;
        closeToSocket = false;
        pluggedInSprite.gameObject.SetActive(false);
        defaultSprite.gameObject.SetActive(true);
    }

    public bool IsGrabbed()
    {
        return grabbed;
    }

    public bool IsPluggedIn()
    {
        return inSocket;
    }

    public void Dangle(bool value)
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        if (value) {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        } else {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
