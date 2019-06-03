using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public bool triggerOnStart = false;
    public Dialog[] dialogs;

    public void Trigger()
    {
        DialogSystem.GetInstance().StartDialog(dialogs);
    }

    private void Start()
    {
        if (triggerOnStart) {
            Trigger();
        }
        
    }

    public void Next()
    {
        DialogSystem.GetInstance().NextDialog();
    }
}
