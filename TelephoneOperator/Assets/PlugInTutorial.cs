using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlugInTutorial : MonoBehaviour
{

    public SocketFemale socket;
    public DialogTrigger trigger;

    public UnityEvent pluggedIn;

    // Update is called once per frame
    void Update()
    {
        if (socket.IsFilled()) {
            trigger.Trigger();
            this.enabled = false;
            pluggedIn.Invoke();
        }
    }
}
