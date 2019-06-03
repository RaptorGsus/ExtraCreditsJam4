using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI titleObject;
    [SerializeField]
    private TextMeshProUGUI bodyObject;
    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }



    private DialogEvent onButtonOneClick;
    private DialogEvent onButtonTwoClick;

    private bool typeText;
    private bool isTyping = false;
    private Dialog dialog;
    public float typeSpeed;

    public void ShowDialog(Dialog newDialog)
    {
        dialog = newDialog;
        titleObject.text = newDialog.title;
        bodyObject.text = newDialog.body;
        button1.GetComponentInChildren<TextMeshProUGUI>().text = newDialog.buttonLabel1.Length > 0 ? newDialog.buttonLabel1 : "Next";
        button2.GetComponentInChildren<Text>().text = newDialog.buttonLabel2;
        if (newDialog.event2.GetPersistentEventCount() > 0) { onButtonTwoClick = newDialog.event2; button2.gameObject.SetActive(true); } else { onButtonTwoClick = null; button2.gameObject.SetActive(false); }
        if (newDialog.event1.GetPersistentEventCount() > 0) { onButtonOneClick = newDialog.event1; } else { onButtonOneClick = null; }
        if (newDialog.typeText) {
            TypeText();
        }

    }

    public void OnButton1Clicked()
    {
        if (isTyping)
        {
            SkipToNextText();
        }
        else if(onButtonOneClick == null)
        {
            DialogSystem.GetInstance().NextDialog();
        }  else
        {
            onButtonOneClick.Invoke(0);
        }
    }

    public void OnButton2Clicked()
    {
        if (!isTyping)
        {
            if (onButtonTwoClick != null)
            {
                onButtonTwoClick.Invoke(0);
            }
            else
            {

            }
        }
       
    }

    public void InTransition()
    {
      anim.SetTrigger("In");
      
    }

    public void OutTransition()
    {
        anim.SetTrigger("Out");
    }

    private void TypeText()
    {
        StartCoroutine(AnimateText());
        isTyping = true;
    }

  
    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        bodyObject.text = dialog.body;
        isTyping = false;
    }
    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (dialog.body.Length); i++)
        {
            bodyObject.text = dialog.body.Substring(0, i);
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }




}
