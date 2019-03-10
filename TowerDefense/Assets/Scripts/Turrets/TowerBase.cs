using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBase : MonoBehaviour
{

    [Header("Barricade")]
    public int barricade_hp = 7;
    public int barricade_upgrade;
    public int barricade_upgrade_2; 
    

    [Header("Maching_Gun_Tower")]
    public int machine_gun_tower_hp;
    public int machine_gun_tower_damage;
    public int machine_gun_tower_fire_rate;
    public int machine_gun_tower_range;
    public int machine_gun_tower_hp_up1;
    public int machine_gun_tower_damage_up1;
    public int machine_gun_tower_fire_rate_up1;
    public int machine_gun_tower_range_up1;
    public int machine_gun_tower_hp_up2;
    public int machine_gun_tower_damage_up2;
    public int machine_gun_tower_fire_rate_up2;
    public int machine_gun_tower_range_up2;

    [Header("Sniper_Tower")]
    public int sniper_tower_hp;
    public int sniper_tower_damage;
    public int sniper_tower_fire_rate;
    public int sniper_tower_range;
    public int sniper_tower_hp_up1;
    public int sniper_tower_damage_up1;
    public int sniper_tower_fire_rate_up1;
    public int sniper_tower_range_up1;
    public int sniper_tower_hp_up2;
    public int sniper_tower_damage_up2;
    public int sniper_tower_fire_rate_up2;
    public int sniper_tower_range_up2;

    [Header("Rocket_Tower")]
    public int rocket_tower_hp;
    public int rocket_tower_damage;
    public int rocket_tower_fire_rate;
    public int rocket_tower_range;
    public int rocket_tower_hp_up1;
    public int rocket_tower_damage_up1;
    public int rocket_tower_fire_rate_up1;
    public int rocket_tower_range_up1;
    public int rocket_tower_hp_up2;
    public int rocket_tower_damage_up2;
    public int rocket_tower_fire_rate_up2;
    public int rocket_tower_range_up2;



    private Building current_build;
    private Tower current_tower;
    private SpriteRenderer sr;
    
    private bool PopUp;



    [Header("Sprites")]
    public Sprite machine_lvl_1;
    public Sprite machine_lvl_2;
    public Sprite machine_lvl_3;
    public Sprite rocket_tower_lvl_1;
    public Sprite rocket_tower_lvl_2;
    public Sprite rocket_tower_lvl_3;
    public Sprite sniper_tower_lvl_1;
    public Sprite sniper_tower_lvl_2;
    public Sprite sniper_tower_lvl_3;
    public Sprite barricade_lvl_1;
    public Sprite barricade_lvl_2;  


    [Header("Player GameObject")]
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current_build is Tower)
        {
            current_tower = (Tower)current_build;
            //sr.sprite = machine_lvl_1;
            current_tower.attack(current_tower.damage);
        }

        else if (current_build is Barricade)
        {
            //sr.color = new Color(255,0,0);
        }
        else
        {
            //Debug.Log("I am a barricade");
        }
    }

    /*
    if player touches it and it will look at his gold

    4 options show up
    1)Barricade
    2)machine gun tower
    3)Sniper tower
    4)rocket tower

        each changes the sprite of the current gameobject and properties 
     */

    private void OnMouseOver() 
    {
        //Debug.Log("Im clicking");
         if(Input.GetMouseButtonDown(0))
         {
              Debug.Log("Im clicking");
             PopUp= true;

         }
     }

     private void OnGUI() 
     {
         DrawInfo();
     }

     void DrawInfo()
     {
         Rect rect= new Rect (new Vector2(10,5),new Vector2(300,300));
         Rect rect1= new Rect (new Vector2(10,50),new Vector2(100,50));
         Rect rect2= new Rect (new Vector2(10,100),new Vector2(100,50));
         Rect rect3= new Rect (new Vector2(10,150),new Vector2(100,50));
         Rect rect4 = new Rect (new Vector2(10,200),new Vector2(100,50));
         if (PopUp)
         {
             GUI.Box(rect,"Buying Tower");
             if(GUI.Button(rect1,"Machine Gun"))
             {
                 current_build = new Machine_Gun_Tower(1,1,1,1);
                 sr.sprite = machine_lvl_1;
                 PopUp = false;
             }
             if (GUI.Button(rect2,"Sniper Gun"))
             {
                 current_build = new Sniper_Gun_Tower(10,100,10,1);
                 sr.sprite = sniper_tower_lvl_1;
                 PopUp = false;
             }
             if (GUI.Button(rect3,"Rocket Gun"))
             {
                 current_build = new Rocket_Gun_Tower(3,10,50,10);
                 sr.sprite = rocket_tower_lvl_1;
                 PopUp = false;
             }
             if(GUI.Button(rect4,"Barricade"))
             {
                 current_build = new Barricade(5);
                 sr.sprite = barricade_lvl_1;
                 PopUp = false;
             }
         }
            

     }
}
