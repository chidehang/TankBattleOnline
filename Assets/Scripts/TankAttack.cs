using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TankAttack : NetworkBehaviour {

    public GameObject shell;
    public float shellSpeed = 15;

    private Transform fireSpwan;
    private AudioSource fireAudio;

	// Use this for initialization
	void Start () {
        fireSpwan = transform.Find("FireSpawn");
        fireAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
	}

    [Command]
    public void CmdFire()
    {
        fireAudio.Play();
        GameObject go = GameObject.Instantiate(shell, fireSpwan.position, fireSpwan.rotation);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;

        NetworkServer.Spawn(go);
    }
}
