using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public List<Gun> guns = new List<Gun>();

    private Transform shoot_pos;
    private GameObject bullet_prefab;

    private float start_time_between_shots;
    private float time_between_shots;

    private AudioSource shoot_sound;


    private Gun selectedGun;
    private int gunIndex = 0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        selectedGun = guns[gunIndex];
        start_time_between_shots = selectedGun.shoot_time;
        shoot_sound = FindObjectOfType<SFXManager>().FindSFX(selectedGun.shot_sound);
        bullet_prefab = selectedGun.bullet_prefab;
        GetComponent<SpriteRenderer>().sprite = selectedGun.player_sprite;
        shoot_pos = selectedGun.shoot_pos;

        shoot_pos.rotation = transform.rotation;

        if (Input.GetButtonDown("R1"))
        {
            NextWeapon();
        }
        if (Input.GetButtonDown("L1"))
        {
            PreviousWeapon();
        }

        if (selectedGun.name != "rifle")
        {
            FindObjectOfType<SFXManager>().FindSFX("rifle_shot").Stop();
        }

        if (time_between_shots <= 0)
        {
            if (!selectedGun.autofire)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootWeapon();
                    time_between_shots = start_time_between_shots;
                }
            }
            else if (selectedGun.autofire)
            {
                if (Input.GetButton("Fire1"))
                {
                    ShootWeapon();
                    time_between_shots = start_time_between_shots;
                    if (!shoot_sound.isPlaying)
                        shoot_sound.Play();
                }
                if (!Input.GetButton("Fire1"))
                shoot_sound.Stop();
            }
           
        }
        else
        {
            time_between_shots -= Time.deltaTime;
        }

		
	}

    private void ShootWeapon()
    {
        shoot_sound.Play();
        Instantiate(bullet_prefab, shoot_pos.position, shoot_pos.rotation);
    }

    private void NextWeapon()
    {
        if (gunIndex != guns.Count - 1)
        {
            gunIndex++;
            selectedGun = guns[gunIndex];
        }
        else
        {
            gunIndex = 0;
            selectedGun = guns[gunIndex];
        }
    }
    private void PreviousWeapon()
    {
        if (gunIndex != 0)
        {
            gunIndex--;
            selectedGun = guns[gunIndex];
        }
        else
        {
            gunIndex = guns.Count - 1;
            selectedGun = guns[gunIndex];
        }
    }

}

[System.Serializable]
public class Gun
{
    public string name;
    public GameObject bullet_prefab;
    public Sprite player_sprite;
    public string shot_sound;
    public float shoot_time;
    public Transform shoot_pos;
    public bool autofire = false;
}
