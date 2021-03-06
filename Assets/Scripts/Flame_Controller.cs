﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flame_Controller : WarzoneElement {

    public void Activate()
    {
        App.View.Flame_Building_View.enabled = true;
        for (int i = 0; i < App.View.Flame_Building_View.transform.childCount; ++i)
        {
            App.View.Flame_Building_View.transform.GetChild(i).gameObject.SetActive(true);
        }

        App.Model.Flame_Building_Model.Highlight.SetActive(false);

        //Diasble AR  Purchase Button
        App.Model.UI_Model.FLM_Button.interactable = false;
        App.Model.UI_Model.FLM_Button.GetComponent<Image>().color = App.Model.CC_Model.ActiveTechnology;

        //Activate Flame Shop Button
        App.Model.Shop_Model.b6.interactable = true;
        PlayerVariables.hasFLM = true;

    }

    public void ShowUI()
    {
        App.Model.Flame_Building_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.Flame_Building_Model.UI.SetActive(false);
    }

    public void ShowHighlight()
    {
        App.Model.Flame_Building_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.Flame_Building_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.Flame_Building_Model.Health--;

        if (App.Model.Flame_Building_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {


    }

    public void DestroyBuilding()
    {
        //Destroy(App.View.Flame_Building_View.gameObject);

    }
}
