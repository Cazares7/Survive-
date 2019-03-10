using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    public float speed;
    public float life_time;
    Vector2 direction;

    public GameObject hit_effect;

    Rigidbody2D rb;

    public bool sniper_bullet = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyProjectile", life_time);

        direction = FaceMouse();

        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private Vector2 FaceMouse()
    {
        Vector3 mouse_position = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);

        Vector2 direction = new Vector2(
            mouse_position.x - FindObjectOfType<PlayerController>().transform.position.x,
            mouse_position.y - FindObjectOfType<PlayerController>().transform.position.y);

        direction = direction.normalized;

        return direction;
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
