using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent clicked;
    
    private Outline outline;
    
    // Start is called before the first frame update
    void Start()
    {
        if (clicked == null) clicked = new UnityEvent();
        
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5;
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        clicked.Invoke();
    }
}
