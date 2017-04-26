using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Model : MonoBehaviour {

    public static Shop_Model model;

    [Header("Turret Prefabs")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint boostTower;
    public TurretBlueprint sniper;
    public TurretBlueprint missleLauncher;
    public TurretBlueprint laserTurret;
    public TurretBlueprint flameTurret;

    [Header("TEMP Building Models")]
    public GameObject TEMP_BUILDING_1;
    public GameObject TEMP_BUILDING_2;
    public GameObject TEMP_BUILDING_3;
    public GameObject TEMP_BUILDING_4;
    public GameObject TEMP_BUILDING_5;
    public GameObject TEMP_BUILDING_6;


    private Renderer rend;

    public Color startColour;
    public Color selectedColour;

    [Header("Buttons")]
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;

    [Header("Technology Buttons")]
    public Color ActiveTechnology;
    public Color unlockedText;

    public bool hasArmory = false;
    public bool hasTowerSupportDepot = false;
    public bool hasSniperAcademy = false;
    public bool hasLaserFactory = false;
    public bool hasMissilePlant = false;
    public bool hasAdvancedMunition = false;
    public bool hasIncinerator = false;

    //CC Build Buttons temp?
    public Button tb1;
    public Button tb2;
    public Button tb3;
    public Button tb4;
    public Button tb5;
    public Button tb6;
    public Button tb7;
    public Button tb8;
    

    void Start()
    {
        //Model should never interact wih view of an object
        startColour = b1.GetComponent<Image>().color;
    }

    void Awake()
    {
        if (model != null)
        {
            Debug.Log("Multiple Build Managers");
        }
        model = this;

    }

}
