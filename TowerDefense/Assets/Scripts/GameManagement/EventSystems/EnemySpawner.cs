using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public Waypoints[] paths;
    public int pathIndex;

    public GameObject[] enemyPrefabs;
    public Transform[] spawn_points;
    private int spawn_point_index;
    private int enemy_index = 0;

    private int wave = 1;

    public int max_enemies;
    private int enemy_count;
    private int kill_count = 0;

    public float wave_timer;
    private float wave_time;

    public int enemy_incrementer;

    public float move_speed_incrementer;

    public float spawn_timer;
    private float spawn_time;

    private bool wave_active;

    public float set_move_speed = 5;

    private bool has_incremented_speed = false;

    //For UI
    public Text wave_counter;
	// Use this for initialization
	void Start () {
        wave_time = wave_timer;
        spawn_time = spawn_timer;
	}
	
	// Update is called once per frame
	void Update () {
        //For UI
        wave_counter.text = "Wave: " + wave;

        if (wave % 5 == 0 && !has_incremented_speed)
        {
            IncrementMoveSpeed();
        }
		
        if (kill_count == max_enemies)
        {
            NextWave();
        }
        else
        {
            wave_time -= Time.deltaTime;

            if (spawn_time <= 0f)
            {
                if (enemy_count < max_enemies)
                {
                    SpawnEnemy();
                    spawn_time = spawn_timer;
                }
            }
            else
            {
                spawn_time -= Time.deltaTime;
            }
        }

	}

    private void NextWave()
    {
        enemy_count = 0;
        kill_count = 0;
        max_enemies += enemy_incrementer;
        wave++;
        wave_time = wave_timer;
        has_incremented_speed = false;
    }

    private void SpawnEnemy()
    {
        spawn_point_index = Random.Range(0, spawn_points.Length);
       

        pathIndex = spawn_point_index;
        Instantiate(enemyPrefabs[enemy_index], spawn_points[spawn_point_index].transform.position, Quaternion.identity);
        if (enemy_count != max_enemies)
        {
            enemy_count++;
        }
    }

    private void IncrementMoveSpeed()
    {
        set_move_speed += move_speed_incrementer;
    }

    public void KillEnemy()
    {
        if (kill_count != max_enemies)
        kill_count++;
    }
}
