using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog{

    public Dialog(string title, string body, bool typeText)
    {
        this.title = title;
        this.body = body;
        this.typeText = typeText;
    }
    
    public string title;
    public string body;
    public bool typeText;

    [Header("Button 1")]
    public string buttonLabel1 = "Next";
    [SerializeField]
    public DialogEvent event1;

    [Header("Button 2")]
    public string buttonLabel2;
    [SerializeField]
    public DialogEvent event2;

    

}
