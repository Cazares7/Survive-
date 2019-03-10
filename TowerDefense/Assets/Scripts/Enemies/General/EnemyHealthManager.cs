using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int enemy_max_health;
    public int enemy_current_health;

    public string hit_sound_effect;
    private AudioSource hit_sound;

    private AudioSource death_sound;

    //Visual FX
    public GameObject hit_effect;
    //public GameObject death_effect;
    //public Transform death_effect_pos;

	// Use this for initialization
	void Start () {
        //Set sound effects
        death_sound = FindObjectOfType<SFXManager>().FindSFX("enemy_death");
        hit_sound = FindObjectOfType<SFXManager>().FindSFX(hit_sound_effect);

        enemy_current_health = enemy_max_health;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy_current_health <= 0)
        {
            death_sound.Play();

            FindObjectOfType<EnemySpawner>().KillEnemy();
            //Death effect
            //Instantiate(death_effect, death_effect_pos.transform.position, Quaternion.identity);

            ////DropLoot
            //FindObjectOfType<LootManager>().GetComponent<LootManager>().CalculateLoot(GetComponent<Transform>());

            Destroy(gameObject);
        }
	}

    public void TakeDamage(int damage_to_take)
    {
        hit_sound.Play();

        Instantiate(hit_effect, transform.position, Quaternion.identity);
        enemy_current_health -= damage_to_take;

        //Shake camera
        FindObjectOfType<CameraController>().ShakeCamera();
    }
}
