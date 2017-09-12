using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {

    private float speed = 0.1f;
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(speed,0,0));
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(-speed,0,0));
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(0,0,-speed));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0,0,speed));
        }
        if (Input.GetKey("r"))
        {
            transform.Translate(new Vector3(0,speed,0));
        }
        if (Input.GetKey("f"))
        {
            transform.Translate(new Vector3(0,-speed,0));
        }
	}
}
