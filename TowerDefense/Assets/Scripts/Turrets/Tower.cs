using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class Tower : Building
{
    public abstract int damage
    {
        get;
        set;
    }

    public abstract int fire_rate
    {
        get;
        set;
    }

    public abstract int range
    {
        get;
        set;
    }

    public void attack(int damage_done)
    {
        Debug.Log(damage_done);
    }
}
