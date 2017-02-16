using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];

    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);    //normalized to make sure it always has same fixed sped so speed var is only thing controlling speed
        
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

        }
        
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            //Destory enemy if reaches last waypoint
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];

    }

}
