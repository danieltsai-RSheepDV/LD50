using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent onClick;
    public UnityEvent offClick;

    private Outline outline;
    
    // Start is called before the first frame update
    void Start()
    {
        if (onClick == null) onClick = new UnityEvent();
        if (offClick == null) offClick = new UnityEvent();

        outline = gameObject.AddComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5;
        outline.enabled = false;
    }

    private void OnMouseEnter() 
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
    }
    private void OnMouseUp()
    {
        offClick.Invoke();
    }
}
