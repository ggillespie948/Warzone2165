using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CC_Model : MonoBehaviour {

    public GameObject UI;
    public GameObject Highlight;

    public int Health;

    [Header("Technology Buttons")]
    public Color ActiveTechnology;
    public Color unlockedText;

    //TEMP????
    public int ArmoryCost = 200;
    public int SupportDepotCost = 550;
    public int SniperAcademyCost = 400;
    public int LaserFactoryCost = 600;
    public int MissilePlantCost = 750;
    public int AdvMunitionCost = 1000;
    public int IncineratorCost = 1250;

    public int ArmoryGas = 5;
    public int SupportDepotGas = 5;
    public int SniperAcademyGas = 10;
    public int LaserFactoryGas = 10;
    public int MissilePlantGas = 15;
    public int AdvMunitionGas = 15;
    public int IncineratorGas = 15;

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
