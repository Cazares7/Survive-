using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDManager : MonoBehaviour {
    public PlayerBar health_bar;
    public Text ammo_text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]

public class PlayerBar

{

    public Image bar;

    public Text bar_text;

}