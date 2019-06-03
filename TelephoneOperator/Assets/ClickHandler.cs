using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ClickHandler : MonoBehaviour
{
    public event Click OnClick;
    public delegate void Click(GameObject source, EventArgs e);

    private void OnMouseDown()
    {
        Debug.Log("Clicked!");
        OnClick(gameObject, EventArgs.Empty);
    }

    private void Update()
    {
        
    }

}
