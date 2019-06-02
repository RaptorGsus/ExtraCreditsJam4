using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayWire : MonoBehaviour
{
    public GameObject wire;
    public GameObject spawnedWire;

    private bool grabNewWire;

    private void OnMouseDown()
    {
       spawnedWire = GameObject.Instantiate(wire);
       spawnedWire.GetComponent<Wire>().Grab();
       Hide();
    }

    private void Update()
    {
        if(spawnedWire == null) {
            Show();
        }
    }

    private void Hide()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    private void Show()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
