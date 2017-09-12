using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{

    private const float YMIN = -90;
    private const float YMAX = 90;
    private const float DISTMIN = 1.5f;
    private const float DISTMAX = 40;

    [SerializeField]
    private Transform target;
    private Transform cam;
    //private Vector3 offset;

    [SerializeField]
    private float MouseSensitivity = 2.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float distance = 4.0f;

    private bool controlActive = true;


    public void Start ()
    {
        cam = transform;
        currentX = 197;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X")*MouseSensitivity;
            currentY -= Input.GetAxis("Mouse Y")*MouseSensitivity;
            currentY = Mathf.Clamp(currentY, YMIN, YMAX);

            distance += Input.GetAxis("Mouse ScrollWheel")*-8;
            distance = Mathf.Clamp(distance, DISTMIN, DISTMAX);

            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            cam.position = target.position + new Vector3(0, 0.5f, 0) + rotation * dir;
            cam.LookAt(target.position + new Vector3(0, 0.5f, 0));
        }
    }
        

    public void SetTarget (Transform tar)
    {
        target = tar;
    }
}
