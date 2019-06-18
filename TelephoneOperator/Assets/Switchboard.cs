using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Switchboard : MonoBehaviour
{
    public SocketFemale startSocket;
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
