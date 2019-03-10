using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public Gun weapon;
    public float fireTimerLength;
    float timer;
    public float turn_speed;
    public float range;
	// Use this for initialization
	void Start () {
		
	}
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            //Fire at player here
            timer = fireTimerLength;
        }
	}

    private void Shoot()
    {

    }

    
    
}
