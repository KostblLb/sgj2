using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float vSpeed = 1;
    public float hSpeed = 1;

    Rigidbody2D rgbd;

    // Use this for initialization
    void Start () {
        rgbd = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rgbd.velocity = new Vector2(hSpeed, vSpeed);
        //transform.position = transform.position + new Vector3(hSpeed, vSpeed, 0);
	}
}
