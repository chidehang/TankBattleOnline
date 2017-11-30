using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour {

    public float delayTime;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, delayTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
