using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour {

    //MVC Singketon Pattern
    public static shop model;

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

    private Color startColour;
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

    private bool Armory = false;
    private bool TowerSupportDepot = false;
    private bool SniperAcademy = false;
    private bool LaserFactory = false;
    private bool MissilePlant = false;
    private bool AdvancedMunition = false;
    private bool Incinerator = false;

    //CC Build Buttons temp?
    public Button tb1;
    public Button tb2;
    public Button tb3;
    public Button tb4;
    public Button tb5;
    public Button tb6;
    public Button tb7;
    public Button tb8;

    //TEMP
    private int ArmoryCost = 200;
    private int SupportDepotCost = 550;
    private int SniperAcademyCost = 400;
    private int LaserFactoryCost = 600;
    private int MissilePlantCost = 750;
    private int AdvMunitionCost = 1000;
    private int IncineratorCost = 1250;

    private int ArmoryGas = 5;
    private int SupportDepotGas = 5;
    private int SniperAcademyGas = 10;
    private int LaserFactoryGas = 10;
    private int MissilePlantGas = 15;
    private int AdvMunitionGas = 15;
    private int IncineratorGas = 15;






    void Start()
    {
        startColour = b1.GetComponent<Image>().color;
        ActiveTechnology = Color.green;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) && b1.IsInteractable())
        {
            SelectTurret1();          
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha2) && TowerSupportDepot)
        {
            SelectTurret2();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha3) && SniperAcademy)
        {
            SelectTurret3();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha4) && MissilePlant)
        {
            SelectTurret4();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha5) && LaserFactory)
        {
            SelectTurret5();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6) && Incinerator)
        {
            SelectTurret6();
        }
        else
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UIReset();
            BuildManager.instance.SetBuildTurret(null);
            BuildManager.instance.SetSelectedNode(null);
        }
    }

    

    public void SelectTurret1()
    {
        BuildManager.instance.SetBuildTurret(standardTurret);
        UIReset();
        b1.GetComponent<Image>().color = selectedColour;
    }

    public void SelectTurret2()
    {
        BuildManager.instance.SetBuildTurret(boostTower);
        UIReset();
        b2.GetComponent<Image>().color = selectedColour;
    }

    public void SelectTurret3()
    {
        BuildManager.instance.SetBuildTurret(sniper);
        UIReset();
        b3.GetComponent<Image>().color = selectedColour;
    }

    public void SelectTurret4()
    {
        BuildManager.instance.SetBuildTurret(missleLauncher);
        UIReset();
        b4.GetComponent<Image>().color = selectedColour;
    }

    public void SelectTurret5()
    {
        BuildManager.instance.SetBuildTurret(laserTurret);
        UIReset();
        b5.GetComponent<Image>().color = selectedColour;
    }

    public void SelectTurret6()
    {
        BuildManager.instance.SetBuildTurret(flameTurret);
        UIReset();
        b6.GetComponent<Image>().color = selectedColour;
    }

    public void UIReset()
    {
        Debug.Log("UI Reset");
        b1.GetComponent<Image>().color = startColour;
        b2.GetComponent<Image>().color = startColour;
        b3.GetComponent<Image>().color = startColour;
        b4.GetComponent<Image>().color = startColour;
        b5.GetComponent<Image>().color = startColour;
        b6.GetComponent<Image>().color = startColour;

    }

    public void BuyArmory()
    {
        
        

    }

    public void BuyTowerSupportDepot()
    {
        if (PlayerVariables.Cash >= SupportDepotCost && PlayerVariables.Oil >= SupportDepotGas)
        {
            PlayerVariables.Cash -= SupportDepotCost;
            PlayerVariables.Oil -= SupportDepotGas;

            TowerSupportDepot = true;
            b2.interactable = true;

            tb6.interactable = false;
            tb6.GetComponent<Image>().color = ActiveTechnology;
        }
        

    }

    public void BuySniperAcademy()
    {
        

        if (PlayerVariables.Cash >= SniperAcademyCost && PlayerVariables.Oil >= SniperAcademyGas)
        {
            PlayerVariables.Cash -= SniperAcademyCost;
            PlayerVariables.Oil -= SniperAcademyGas;

            SniperAcademy = true;
            b3.interactable = true;

            TEMP_BUILDING_3.SetActive(true);

            tb3.interactable = false;
            tb3.GetComponent<Image>().color = ActiveTechnology;
        }
        

    }

    public void BuyLaserFactory()
    {
        if (PlayerVariables.Cash >= LaserFactoryCost && PlayerVariables.Oil >= LaserFactoryGas)
        {
            PlayerVariables.Cash -= LaserFactoryCost;
            PlayerVariables.Oil -= LaserFactoryGas;

            LaserFactory = true;
            b5.interactable = true;

            TEMP_BUILDING_4.SetActive(true);

            tb4.interactable = false;
            tb4.GetComponent<Image>().color = ActiveTechnology;

        }
        

    }

    public void BuyMissilePlant()
    {
        if (PlayerVariables.Cash >= MissilePlantCost && PlayerVariables.Oil >= MissilePlantGas)
        {
            PlayerVariables.Cash -= MissilePlantCost;
            PlayerVariables.Oil -= MissilePlantGas;

            MissilePlant = true;
            b4.interactable = true;

            TEMP_BUILDING_5.SetActive(true);

            tb5.GetComponent<Image>().color = ActiveTechnology;
            tb5.interactable = false;
            

        }

    }

    public void BuyAdvancedMunition()
    {

        if (PlayerVariables.Cash >= AdvMunitionCost && PlayerVariables.Oil >= AdvMunitionGas)
        {
            PlayerVariables.Cash -= AdvMunitionCost;
            PlayerVariables.Oil -= AdvMunitionGas;

            tb4.interactable = true;
            tb5.interactable = true;
            tb6.interactable = true;
            tb8.interactable = true;

            tb4.GetComponentInChildren<Text>().color = unlockedText;
            tb5.GetComponentInChildren<Text>().color = unlockedText;
            tb6.GetComponentInChildren<Text>().color = unlockedText;
            tb8.GetComponentInChildren<Text>().color = unlockedText;

            TEMP_BUILDING_2.SetActive(true);

            tb7.GetComponent<Image>().color = ActiveTechnology;
            tb7.interactable = false;


        }

    }

    public void BuyIncinerator()
    {

        if (PlayerVariables.Cash >= IncineratorCost && PlayerVariables.Oil >= IncineratorGas)
        {
            PlayerVariables.Cash -= IncineratorCost;
            PlayerVariables.Oil -= IncineratorGas;
            Incinerator = true;
            b6.interactable = true;

            TEMP_BUILDING_6.SetActive(true);
            tb8.GetComponent<Image>().color = ActiveTechnology;

        }

    }

    //Method that sends raycast to out to find node then changes colour of node based on selectedTurrest status
    //method called on every selection  





}
