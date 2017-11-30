using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TankHealth : NetworkBehaviour {

    public float initalHP = 100;
    public GameObject tankExplostion;
    public AudioClip diedAudio;

    [SyncVar(hook = "OnHealthChanged")]
    private float hp;
    private Slider hpSlider;

	// Use this for initialization
	void Start () {
        hp = initalHP;
        hpSlider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamaged(float damage)
    {
        if (!isServer) return;

        if (hp <= 0) return;

        hp -= damage;
        
        if (hp <= 0)
        {
            if (tankExplostion)
                GameObject.Instantiate(tankExplostion, transform.position+Vector3.up, transform.rotation);
            if (diedAudio)
                AudioSource.PlayClipAtPoint(diedAudio, transform.position);

            GameObject.Destroy(this.gameObject);
        }
    }

    public void OnHealthChanged(float health)
    {
        hp = health;
        if(hpSlider)
            hpSlider.value = hp / initalHP;
    }
}
