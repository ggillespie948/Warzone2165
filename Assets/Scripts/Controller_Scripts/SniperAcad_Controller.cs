using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperAcad_Controller : WarzoneElement {

    public void Activate()
    {
        App.View.SniperAcad_View.enabled = true;
        for (int i = 0; i < App.View.SniperAcad_View.transform.childCount; ++i)
        {
            App.View.SniperAcad_View.transform.GetChild(i).gameObject.SetActive(true);
        }

        App.Model.SniperAcad_Model.Highlight.SetActive(false);

        //Diasble AR  Purchase Button
        App.Model.UI_Model.SNP_Button.interactable = false;
        App.Model.UI_Model.SNP_Button.GetComponent<Image>().color = App.Model.CC_Model.ActiveTechnology;

        //Activate Sniper Turret Button
        App.Model.Shop_Model.b3.interactable = true;

        PlayerVariables.hasSniperAcademy = true;

    }

    public void ShowUI()
    {
        App.Model.SniperAcad_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.SniperAcad_Model.UI.SetActive(false);
    }

    public void ShowHighlight()
    {
        App.Model.SniperAcad_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.SniperAcad_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.SniperAcad_Model.Health--;

        if (App.Model.SniperAcad_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {


    }

    public void DestroyBuilding()
    {
        PlayerVariables.hasSniperAcademy = false;

    }
}
