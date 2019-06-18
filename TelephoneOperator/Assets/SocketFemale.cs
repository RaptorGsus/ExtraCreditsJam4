using System;
using UnityEngine;

public class SocketFemale : MonoBehaviour
{
    public bool end = false;
    public enum SocketType
    {
        IN,
        OUT
    }

    public SocketType socketType;
    private WirePlug wirePlug;

    public bool IsFilled()
    {
        return wirePlug != null;
    }

    internal SwitchSocket GetSwitch()
    {
        return GetComponentInParent<SwitchSocket>();
    }

    public void PlugIn(WirePlug plug)
    {
        Debug.Log("Plugging in");
        wirePlug = plug;
        //GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void Unplug()
    {
        Debug.Log("Plugging out");

        wirePlug = null;
        //GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    public WirePlug GetPlug()
    {
        return wirePlug;
    }
}
