﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Projectile : MonoBehaviour
{
    public float speed;
    public float life_time;
    Vector2 direction;

    public GameObject tile;

    public GameObject hit_effect;

    Rigidbody2D rb;

    public bool sniper_bullet = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", life_time);
        Vector3 direction = tile.transform.position + new Vector3(3,100,0);
        direction = direction.normalized;
        rb.velocity = new Vector2( direction.x * speed , direction.y  * speed );
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyHealth")
        {
            if (!sniper_bullet)
            DestroyProjectile();

            if (sniper_bullet)
                Instantiate(hit_effect, transform.position, Quaternion.identity);
            //hit_sound.Play();
        }

    }

    void DestroyProjectile ()
    {
        Instantiate(hit_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
