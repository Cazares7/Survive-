using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int player_max_health;
    public float player_current_health;
    public float start_invincibility_frames;
    private float invincibility_frames;

    public GameObject health_collision;
    //For displaying healeffect
    //public GameObject heal_effect;
    private bool dead = false;
    private bool respawned = false;
    public Transform spawn_point;
    public Transform the_player;

    //For flashing player when hit
    private SpriteRenderer sprite;

    public float respawn_timer;
    private float respawn_time;

    //SFX
    private AudioSource take_damage;

    void Start () {
        //Gets access to player sprite
        sprite = GetComponent<SpriteRenderer>();
        take_damage = FindObjectOfType<SFXManager>().FindSFX("player_hurt");

        player_current_health = player_max_health;

        // Initializes the player's health to given health values
    }
	
	// Update is called once per frame
	void Update () {
        if (respawn_time <= 0)
        {
            if (!respawned)
            {
                the_player.position = spawn_point.position;
                health_collision.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Shoot>().enabled = true;
                player_current_health = player_max_health;
                dead = false;
                respawned = true;
            }

        }
        else
        {
            respawn_time -= Time.deltaTime;
        }

        //changes the health bar and text based on player's current health
        FindObjectOfType<PlayerHUDManager>().health_bar.bar.fillAmount = player_current_health / player_max_health;
        FindObjectOfType<PlayerHUDManager>().health_bar.bar_text.text = player_current_health + "/" + player_max_health;

        //Player dies if health reaches 0
        if (player_current_health <= 0)
        {
            if (FindObjectOfType<Base>().current_health <= 0)
            {
                FindObjectOfType<Gameover>().EndGame();
            }
            else
            {
                if (!dead)
                    Respawn();
                dead = true;

                health_collision.SetActive(false);
            }

            //GetComponent<PlayerInputManager>().SwitchInput(false);
            if (!dead)
                Respawn();
                dead = true;

            health_collision.SetActive(false);
            //GetComponent<Animator>().SetBool("Dead", true);
            //gameObject.SetActive(false);
        }

        //Temporary Invincibilty
        if (invincibility_frames > 0)
        {
            invincibility_frames -= Time.deltaTime;
            health_collision.gameObject.SetActive(false);

            //Flash player when hit
            if (invincibility_frames < start_invincibility_frames)
            {
                sprite.color = new Color(1, 1, 1, 0.5f);
            }
            if (invincibility_frames < start_invincibility_frames * 0.7f)
            {
                sprite.color = new Color(1, 1, 1, 1f);
            }
            else if (invincibility_frames < start_invincibility_frames * 0.3f)
            {
                sprite.color = new Color(1, 1, 1, 0.5f);
            }
            else
            {
                sprite.color = new Color(1, 1, 1, 1f);
            }
        }
        else
        {
            health_collision.gameObject.SetActive(true);
        }

        //Make sure player doesnt go over max health
        if (player_current_health > player_max_health)
        {
            player_current_health = player_max_health;

            
        }
        
    }

    //Take Damage
    public void TakeDamage(int damage)
    {
        if (!dead)
        {
            take_damage.Play();

            player_current_health -= damage;
            invincibility_frames = start_invincibility_frames;

        }
    }

    //Get health
    public void RaiseHealth(int health_to_raise)
    {
        player_current_health += health_to_raise;

        //Display heal effect
        //Instantiate(heal_effect, transform.position, Quaternion.identity);

     
    }

    //Upgrade Health
    public void UpgradeHealth(int health_to_upgrade)
    {
        player_max_health += health_to_upgrade;
        player_current_health = player_max_health;

       
    }

    //For ghosting through enemies when hurt
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (invincibility_frames > 0f)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
            }
        }
    }

    private void Respawn()
    {
        respawn_time = respawn_timer;
        respawned = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Shoot>().enabled = false;
    }
}
