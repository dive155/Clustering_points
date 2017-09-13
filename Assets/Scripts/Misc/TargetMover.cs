using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {

    private float speed = 0.1f;
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("d"))
        {
            transform.Translate( Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(speed,0,0));
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(-speed,0,0));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(0,0,-speed));
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(0,0,speed));
        }
        if (Input.GetKey("r"))
        {
            transform.Translate(Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(0,speed,0));
        }
        if (Input.GetKey("f"))
        {
            transform.Translate(Quaternion.LookRotation(Camera.main.transform.forward) * new Vector3(0,-speed,0));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 0.1f;
        }
	}
}
