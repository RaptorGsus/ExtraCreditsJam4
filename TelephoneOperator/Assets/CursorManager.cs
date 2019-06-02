using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public WirePlug HeldPlug { get { return plug; } set { plug = value; } }
    private WirePlug plug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
