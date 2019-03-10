using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Gun_Tower : Tower
{
    int _hp;
    int _range;
    int _damage;
    int _fire_rate;

    public Rocket_Gun_Tower(int hp, int range, int damage, int fire_rate)
    {
        _hp = hp;
        _range = range;
        _damage = damage;
        _fire_rate = fire_rate;
    }

    
    public override int hp
    {
        get
        {
            return _hp;
        }
        set{ 
            _hp = hp;
         }
    }
    public override int range
    {
        get
        {
            return _range;
        }
        set{  
            _range = range;
        }
    }
    public override int damage
    {
        get
        {
            return _damage;
        }
        set{
            _damage = damage;
        }
    }
    public override int fire_rate
    {
        get
        {
            return _fire_rate;
        }
        set{
            _fire_rate = fire_rate;
         }
    }
    
    public override void upgrade()
    {
        if (can_upgrade(700, 600))
        {
            //Debug.Log("NO UPGRADE");
        }
        else
        {
            _damage = damage + 5;
            _fire_rate = fire_rate + 5;
            _range = range + 5;
            //Debug.Log(damage + 5);
            //Debug.Log(fire_rate+ 5);
            //Debug.Log(range+ 5);
        }
    }
}
