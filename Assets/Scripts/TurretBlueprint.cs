using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint{

    public string tag;
    public GameObject prefab;
    public GameObject upgradePrefab;
    public int cost;
    public int ps;
    public int upgradeCost;
    public int baseRange;
    public string Description = "A standard rail-gun turret, cheap and effective.";

	
}
