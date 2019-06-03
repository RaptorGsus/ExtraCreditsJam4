using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchboard : MonoBehaviour
{
    List<SwitchSocket> sockets;
    // Start is called before the first frame update
    void Start()
    {
        sockets = new List<SwitchSocket>();
        var foundSockets = GetComponentsInChildren<SwitchSocket>();
        foreach(SwitchSocket s in foundSockets) {
            sockets.Add(s);
        }
    }
}
