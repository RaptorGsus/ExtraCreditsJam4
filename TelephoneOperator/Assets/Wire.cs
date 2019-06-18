using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : Node
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

    public override string Visit(ref string expression)
    {
        expression += addition;
        Node next = GetNextNode();
        if (next != null) {
            return next.Visit(ref expression);
        } else {
            return expression;
        }
    }

    private Node GetNextNode()
    {
        if (!plugOne.IsPluggedIn() || !plugTwo.IsPluggedIn()) return null;
        if (plugOne.GetSocketType() == SocketFemale.SocketType.IN && plugTwo.GetSocketType() == SocketFemale.SocketType.OUT) return plugOne.GetSocket().GetSwitch();
        if (plugOne.GetSocketType() == SocketFemale.SocketType.OUT && plugTwo.GetSocketType() == SocketFemale.SocketType.IN) return plugTwo.GetSocket().GetSwitch();
        return null;
    }

    public void ResetWire()
    {
        plugOne.Unplug();
        plugTwo.Unplug();
    }
}
