using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAcad_Model : WarzoneElement {

    public GameObject UI;
    public GameObject Highlight;

    public List<GameObject> SniperTurretList;
    public GameObject IncinAmmo;

    public int Health = 10;

    public GameObject WaypointObject;

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
