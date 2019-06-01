using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CableRenderer : MonoBehaviour
{
    //Points to connect using a line.
    public Transform[] lineSegments;
    private LineRenderer lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the positions of Cable segments.
        lineRenderer.positionCount = lineSegments.Length;
        for (int i = 0; i < lineSegments.Length; i++) {
            lineRenderer.SetPosition(i, lineSegments[i].position);
        }
    }
}
