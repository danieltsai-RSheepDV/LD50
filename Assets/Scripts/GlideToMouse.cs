using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideToMouse : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    public bool enabled = true;
    //Y angle is horizontal, x angle is vertical
    [SerializeField] private float maxHorizAngle, maxVertAngle;
    private Vector3 target;
    // Update is called once per frame
    void Update()
    {
        target = Input.mousePosition;
        float yAngle = Mathf.Min(Mathf.Max(-1, 2 * (target.x / Screen.width - 0.5f)), 1) * maxHorizAngle;
        float xAngle = Mathf.Min(Mathf.Max(-1, -2 * (target.y / Screen.height - 0.5f)), 1) * maxVertAngle;

        Vector3 currRot = Camera.main.transform.eulerAngles;
        if (currRot.x > 180) currRot.x -= 360;
        if (currRot.y > 180) currRot.y -= 360;
        Camera.main.transform.eulerAngles += new Vector3(
            (xAngle - currRot.x) * speed, (yAngle - currRot.y) * speed, 0) / 180 * Mathf.PI;
    }
}
