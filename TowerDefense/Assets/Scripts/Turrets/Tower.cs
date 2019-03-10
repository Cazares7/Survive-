using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class Tower : Building
{
    public abstract Gun turret_gun
    {
        get;
        set;
    }

    public abstract int damage
    {
        get;
        set;
    }

    public abstract float fire_rate
    {
        get;
        set;
    }

    public abstract int range
    {
        get;
        set;
    }

    private float time_between_shots = 0;
    private Vector3 adjust = new Vector3(0,0.2f,0);
    Vector3 mouse_position;
    float d_x, d_y;

    public void attack()
    {     
       Debug.Log(fire_rate);

       if (time_between_shots <= fire_rate)
       {
           time_between_shots += Time.deltaTime;
       }

       else
       {
        GameObject.Instantiate(turret_gun.bullet_prefab, turret_gun.shoot_pos.position + adjust, turret_gun.shoot_pos.rotation );
        time_between_shots = 0;
       } 
    }
}
