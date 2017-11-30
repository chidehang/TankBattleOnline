using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TankMovement : NetworkBehaviour {

    public float speed = 5;
    public float angularSpeed = 10;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update () {
	}

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        float v = Input.GetAxis("Vertical");
        rigidbody.velocity = transform.forward * v * speed;

        float h = Input.GetAxis("Horizontal");
        rigidbody.angularVelocity = transform.up * h * angularSpeed;
    }
}
