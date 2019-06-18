using UnityEngine;
using TMPro;
using System;

public class SwitchSocket : Node
{
    
    [Header("Sockets")]
    public SocketFemale socketIN; 
    public SocketFemale socketOUT;

    public TextMeshProUGUI valueText;

    public int switchValue;
    public bool end = false;

    private void Start()
    {
        if (!end) {
           addition = switchValue.ToString();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (valueText) {
            valueText.text = switchValue.ToString();
        }
        
    }

    public override string Visit(ref string expression)
    {
        expression += addition;
        Node next = null;
        try {
            next = socketOUT.GetPlug().GetWire();
        } catch (NullReferenceException e) {
            
        }
       
        if (next != null) {
            return next.Visit(ref expression);
        } else {
            return expression;
        }
        
    }
}
