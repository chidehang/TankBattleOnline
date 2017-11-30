using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public GameObject shellExplosion;
    public float damage = 20;
    public AudioClip hitAudio;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (hitAudio)
            AudioSource.PlayClipAtPoint(hitAudio, transform.position);

        if (shellExplosion)
            GameObject.Instantiate(shellExplosion, transform.position, transform.rotation);
        Destroy(this.gameObject);

        if(other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<TankHealth>().TakeDamaged(damage);
        }
    }
}
