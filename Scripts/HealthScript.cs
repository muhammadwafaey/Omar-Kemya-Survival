using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health = 100f;
	// Use this for initialization
	void RemoveHealth(float amount)
    {
        health -= amount;
       
    }
}
