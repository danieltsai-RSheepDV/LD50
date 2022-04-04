using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentableObject : MonoBehaviour
{
    [SerializeField] public float zoomSpeed;

    private bool onScreen;
    private bool mouseDown;
    private Vector3 origPosition;
    private Vector3 camPosition;
    private float width;
    private float stepAngle;

    public Vector3 worldPosition;
    private float storedYDistanceFromMouse = 0;
    private float clickTime = 0;

    void Start()
    {
        onScreen = false;
        mouseDown = false;
        width = this.GetComponent<Renderer>().bounds.size.x;
        camPosition = Camera.main.transform.position + Vector3.forward * width;
        origPosition = this.transform.position;
        stepAngle = 90 / Vector3.Distance(camPosition, origPosition) * zoomSpeed * 1.25f;
    }

    public void Update()
    {
        Plane plane = new Plane(Vector3.forward, -camPosition.z);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        
        if (mouseDown)
        {
            transform.position = new Vector3(transform.position.x, worldPosition.y - storedYDistanceFromMouse, transform.position.z);
        }
        else if(onScreen)
        {
            transform.position += Vector3.up * Input.mouseScrollDelta.y / Screen.height * 10 * width;
        }
    }

    private void OnMouseDown()
    {
        clickTime = Time.time;
        mouseDown = onScreen;
        if (onScreen)
        {
            storedYDistanceFromMouse = worldPosition.y - transform.position.y;
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnMouseUp()
    {
        mouseDown = false;
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }
    public void present()
    {
        if (!onScreen || Time.time - clickTime < 0.2f)
        {
            StartCoroutine(rotateStep(!onScreen));
            StartCoroutine(zoomStep(!onScreen));
        }
    }

    public IEnumerator zoomStep(bool expand)
    {
        Vector3 target = expand ? camPosition + Vector3.down * 3 : origPosition;
        while (Vector3.Distance(target, this.transform.position) > zoomSpeed)
        {
            this.transform.position += (Vector3.Normalize(target - this.transform.position) * zoomSpeed);
            yield return null;
        }
        onScreen = expand;
        this.transform.position = target;

    }
    public IEnumerator rotateStep(bool expand)
    {
        for (float i = 0; i < 90; i += stepAngle)
        {
            this.transform.rotation = Quaternion.Euler(expand ? 90 - i: i, 0, 0); ;
            yield return null;
        }
        this.transform.rotation = Quaternion.Euler(expand ? 0 : 90, 0, 0); ;
    }
}
