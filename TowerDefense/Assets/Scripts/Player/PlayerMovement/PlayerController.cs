using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static bool exists;
    public float move_speed;
    
    private Rigidbody2D my_rigid_body;
    private Animator anim;

    //For allowing and disallowing inputs
    public bool can_input = true;

    private bool is_moving = false;

    public GameObject player;
    
    // Use this for initialization
    void Start () {
        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        my_rigid_body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        FaceMouse();
    }

    // Update is called once per frame
    void Update() {


        is_moving = false;


        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f && can_input
             || Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                is_moving = true;
        if ((Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)&& can_input)
        {
            my_rigid_body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * move_speed, my_rigid_body.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            my_rigid_body.velocity = new Vector2(0, my_rigid_body.velocity.y);

        if ((Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) && can_input)
        {
            my_rigid_body.velocity = new Vector2(my_rigid_body.velocity.x, Input.GetAxisRaw("Vertical") * move_speed);
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Vertical") == 0)
            my_rigid_body.velocity = new Vector2(my_rigid_body.velocity.x, 0);

        if (!is_moving)
        {
            my_rigid_body.velocity = Vector2.zero;
        }
        else
        {
            my_rigid_body.velocity = new Vector2(my_rigid_body.velocity.x, my_rigid_body.velocity.y);
        }
        //anim.SetBool("Player_Moving", is_moving);
    }

    private void FaceMouse()
    {
        Vector3 mouse_position = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(mouse_position);

        Vector2 direction = new Vector2(
            mouse_position.x - transform.position.x,
            mouse_position.y - transform.position.y);

        player.transform.up = direction;
    }
}
