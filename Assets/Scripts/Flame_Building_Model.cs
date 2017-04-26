using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Building_Model : WarzoneElement {

    public GameObject Highlight;
    public GameObject UI;
    public int Health;

    public Transform[] waypoints;
    public GameObject WaypointObject;

    void Awake()
    {
        waypoints = new Transform[WaypointObject.transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = WaypointObject.transform.GetChild(i);
        }

    }
}
