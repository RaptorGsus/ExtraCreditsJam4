using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public WirePlug plugOne;
    public WirePlug plugTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grab()
    {
        plugOne.Grab();
        plugTwo.Dangle(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(!plugOne.IsPluggedIn() && !plugOne.IsGrabbed() &&
            !plugTwo.IsPluggedIn() && !plugTwo.IsGrabbed()) {
            GameObject.Destroy(this.gameObject, 0.5f);
        }
    }
}
