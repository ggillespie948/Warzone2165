using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Controller : MonoBehaviour {

    //Singleton Pattern
    public static Shop_Controller controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectTurret1()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.standardTurret);
        UIReset();
        Shop_Model.model.b1.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void SelectTurret2()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.boostTower);
        UIReset();
        Shop_Model.model.b2.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void SelectTurret3()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.sniper);
        UIReset();
        Shop_Model.model.b3.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void SelectTurret4()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.missleLauncher);
        UIReset();
        Shop_Model.model.b4.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void SelectTurret5()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.laserTurret);
        UIReset();
        Shop_Model.model.b5.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void SelectTurret6()
    {
        BuildManager.instance.SetBuildTurret(Shop_Model.model.flameTurret);
        UIReset();
        Shop_Model.model.b6.GetComponent<Image>().color = Shop_Model.model.selectedColour;
    }

    public void UIReset()
    {
        Debug.Log("UI Reset");
        Shop_Model.model.b1.GetComponent<Image>().color = Shop_Model.model.startColour;
        Shop_Model.model.b2.GetComponent<Image>().color = Shop_Model.model.startColour;
        Shop_Model.model.b3.GetComponent<Image>().color = Shop_Model.model.startColour;
        Shop_Model.model.b4.GetComponent<Image>().color = Shop_Model.model.startColour;
        Shop_Model.model.b5.GetComponent<Image>().color = Shop_Model.model.startColour;
        Shop_Model.model.b6.GetComponent<Image>().color = Shop_Model.model.startColour;

    }

    void Awake()
    {
        if (controller != null)
        {
            Debug.Log("Multiple Build Managers");
        }
        controller = this;

    }
}
