using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem {

    private static DialogSystem instance;

    private DialogBox box;
    private Queue<Dialog> dialogs;
 
    protected DialogSystem() {

        GameObject boxObject = GameObject.FindGameObjectWithTag("DialogBox");

        if (boxObject != null)
        {
            box = boxObject.GetComponent<DialogBox>();
        }
    }

    public static DialogSystem GetInstance()
    {
        //Lazy Initialization 
        if (instance == null)
        {
            instance = new DialogSystem();
        }
        return instance;
       
    }

    public void NextDialog()
    {
        if (dialogs.Count > 0)
        {
            box.ShowDialog(dialogs.Dequeue());

        } else
        {
            box.OutTransition();
        }
    }

    public void StartDialog(Dialog[] newDialogs)
    {
        dialogs = new Queue<Dialog>();
        foreach (Dialog dialog in newDialogs)
        {
            dialogs.Enqueue(dialog);
        }
        box.InTransition();
        NextDialog();
        
    }

    public int getRemainingDialogCount()
    {
        return dialogs.Count;
    }



    

    
    

    
}
