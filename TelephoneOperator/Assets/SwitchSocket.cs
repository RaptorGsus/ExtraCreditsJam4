using UnityEngine;
using TMPro;

public class SwitchSocket : MonoBehaviour
{
    [Header("Sockets")]
    public GameObject socketIN;
    public GameObject socketOUT;

    public TextMeshProUGUI valueText;

    public int socketValue;

    private bool inPlugged;
    private bool outPlugged;
    // Start is called before the first frame update
    void Awake()
    {
        valueText.text = socketValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
}
