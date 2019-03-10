using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour

{

    private float speed;

    private Transform target;

    public float chaseIfClose;

    private bool follow_goal;

    private Waypoints wpoints;
    private int waypoint_index;



    void Start()

    {
        speed = FindObjectOfType<EnemySpawner>().set_move_speed;

        waypoint_index = 0;
        wpoints = FindObjectOfType<EnemySpawner>().paths[FindObjectOfType<EnemySpawner>().pathIndex];
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



    void Update()

    {
        if (follow_goal)
        {
            transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypoint_index].transform.position, speed * Time.deltaTime);

            Vector3 diff = wpoints.waypoints[waypoint_index].transform.position - transform.position;

            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        if (Vector2.Distance(transform.position, wpoints.waypoints[waypoint_index].transform.position) < 0.1f)
        {
            if (waypoint_index < wpoints.waypoints.Length - 1) 
            waypoint_index++;
        }

        if (Vector2.Distance(transform.position, target.position) < chaseIfClose)

        {
            follow_goal = false;

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 diff = target.position - transform.position;

            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            follow_goal = true;
        }

    }

}
