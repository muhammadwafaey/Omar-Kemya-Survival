using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class ZombieDeath : MonoBehaviour
{

    public int EnemyHealth = 5;
    public GameObject TheEnemy;
    public int StatusCheck;
	public Collider cod;

	[Header("Damage Settings")]
	public float damage =  20.0f;
	public float secondToDamagePlayer = 1.0f;
	// privates
	IEnumerator damagePlayer = null;
	IEnumerator healPlayer = null;
	[Header("Objects Settings")]
	public GameObject player;

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.transform.tag == "FPS Controller")
		{
			if (collider.gameObject.GetComponent<FirstPersonController>().paused)
				return;

			Debug.Log("Player can see slender");
			collider.gameObject.transform.Find("Main Camera").gameObject.GetComponent<GlitchEffect>().enabled = true;

			// Stop to heal player
			if (healPlayer != null)
				StopCoroutine(healPlayer);

			// hurt player
			Debug.Log("Start hurting player");
			damagePlayer = collider.gameObject.GetComponent<FirstPersonController>().RemovePlayerHealth(damage, secondToDamagePlayer);
			StartCoroutine(damagePlayer);
		                 
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.transform.tag == "FPS Controller")
		{
			if (collider.gameObject.GetComponent<FirstPersonController>().paused)
				return;

			Debug.Log("Player can't see slender anymore");
			collider.gameObject.transform.Find("Main Camera").gameObject.GetComponent<GlitchEffect>().enabled = false;

			// stop hurting player
			Debug.Log("Stop hurting player");
			StopCoroutine(damagePlayer);

			// start healling player
			healPlayer = collider.gameObject.GetComponent<FirstPersonController>().StartHealPlayer(collider.gameObject.GetComponent<FirstPersonController>().healValue,
				collider.gameObject.GetComponent<FirstPersonController>().secondToHeal);

			Debug.Log("Start healling player");
			StartCoroutine(healPlayer);
		}
	}

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
 
    }

    void Killed()
    {
        Destroy(TheEnemy);
    }
    void Update()
    {
		OnTriggerEnter (cod);
		OnTriggerExit (cod);
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
                
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("walk");
            TheEnemy.GetComponent<Animation>().Play("back_fall");
            Invoke("Killed", 0.7f);
        }

    }

    void Start()
    {
      
    }

    
}
