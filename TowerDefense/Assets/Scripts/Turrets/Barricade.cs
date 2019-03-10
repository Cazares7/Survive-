using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Building
{
    int _hp;

    public Barricade(int hp)
    {
        _hp = hp;
    }

    public override int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = hp;
        }
    }
    
    public override void upgrade()
    {
        _hp += 6;
    }
}
