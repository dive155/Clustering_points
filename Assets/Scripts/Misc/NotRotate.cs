using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotRotate : MonoBehaviour {
    Quaternion rotation;
    void Awake()
    {
        //rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
