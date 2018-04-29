using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject TheEnemy;
    public Transform target;
    public Transform myTransform;
    public int  movespeed = 1;
    public float distance = 3f;

    void Update()
    {


        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movespeed);

        

    }
}
