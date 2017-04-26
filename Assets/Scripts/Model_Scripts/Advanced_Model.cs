using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanced_Model : WarzoneElement {

    public GameObject Highlight;
    public GameObject UI;
    public int Health;

    public UnityEngine.UI.Button UpgradeButton;
    public int Level1UpgradeCost = 1000;
    public int Level1UpgradeGas = 15;

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
