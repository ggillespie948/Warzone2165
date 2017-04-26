using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileFactory_Controller : WarzoneElement {

    //Generic
    public void Activate()
    {
        App.View.MissileFactory_View.enabled = true;
        for (int i = 0; i < App.View.MissileFactory_View.transform.childCount; ++i)
        {
            App.View.MissileFactory_View.transform.GetChild(i).gameObject.SetActive(true);
        }

        App.Model.MissileFactory_Model.Highlight.SetActive(false);

        //Diasble Missile Purchase Button
        App.Model.UI_Model.MSL_Button.interactable = false;
        App.Model.UI_Model.MSL_Button.GetComponent<Image>().color = App.Model.CC_Model.ActiveTechnology;

        //Activate Missile Shop Button
        App.Model.Shop_Model.b4.interactable = true;
        PlayerVariables.hasMissileFactory = true;
        

    }

    public void ShowUI()
    {
        App.Model.AR_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.MissileFactory_Model.UI.SetActive(false);
    }

    public void ShowHighlight()
    {
        App.Model.MissileFactory_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.MissileFactory_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.MissileFactory_Model.Health--;

        if (App.Model.MissileFactory_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {


    }

    public void DestroyBuilding()
    {

    }
}
