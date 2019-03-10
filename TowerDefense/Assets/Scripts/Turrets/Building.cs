using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Building
{
    public abstract int hp
    {
        get;
        set;
    }
    public abstract void upgrade();

    public void taking_damage(int damage)
    {
        hp = hp - damage;
        Debug.Log(hp - damage);
    }

    public bool can_upgrade(int gold, int cost)
    {
        if (gold < cost)
        {
            Debug.Log("YOU CAN NOT UPGRADE");
        }

        return gold < cost;
    }


}
