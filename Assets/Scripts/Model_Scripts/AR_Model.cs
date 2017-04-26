using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Model : WarzoneElement {

    public GameObject Highlight;
    public GameObject UI;
    public GameObject WaypointObject;

    public int Health;

    public Transform[] waypoints;

    void Awake()
    {
        waypoints = new Transform[WaypointObject.transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = WaypointObject.transform.GetChild(i);
        }

    }

}
