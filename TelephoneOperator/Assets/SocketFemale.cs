using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketFemale : MonoBehaviour
{
    private WirePlug wirePlug;

    public bool IsFilled()
    {
        return wirePlug != null;
    }

    public void PlugIn(WirePlug plug)
    {
        Debug.Log("Plugging in");
        wirePlug = plug;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void Unplug()
    {
        Debug.Log("Plugging out");

        wirePlug = null;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
