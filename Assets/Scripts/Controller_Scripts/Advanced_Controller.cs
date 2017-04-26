using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Advanced_Controller : WarzoneElement {

    public void Activate()
    {
        App.View.Advanced_View.enabled = true;
        for (int i = 0; i < App.View.AR_View.transform.childCount; ++i)
        {
            App.View.Advanced_View.transform.GetChild(i).gameObject.SetActive(true);
        }

        App.Model.Advanced_Model.Highlight.SetActive(false);

        //Diasble AR  Purchase Button
        App.Model.UI_Model.ADV_Button.interactable = false;
        App.Model.UI_Model.ADV_Button.GetComponent<Image>().color = App.Model.CC_Model.ActiveTechnology;

        //Activate missile, laser, flame 
        App.Model.UI_Model.MSL_Button.interactable = true;
        App.Model.UI_Model.MSL_Button.GetComponentInChildren<Text>().color = App.Model.CC_Model.unlockedText;

        App.Model.UI_Model.LSR_Button.interactable = true;
        App.Model.UI_Model.LSR_Button.GetComponentInChildren<Text>().color = App.Model.CC_Model.unlockedText;

        App.Model.UI_Model.FLM_Button.interactable = true;
        App.Model.UI_Model.FLM_Button.GetComponentInChildren<Text>().color = App.Model.CC_Model.unlockedText;

    }

    public void ShowUI()
    {
        App.Model.Advanced_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.Advanced_Model.UI.SetActive(false);
    }

    public void ShowHighlight()
    {
        App.Model.Advanced_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.Advanced_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.Advanced_Model.Health--;

        if (App.Model.Advanced_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {


    }

    public void DestroyBuilding()
    {
        //Destroy(App.View.Advanced_View.gameObject);
        Debug.Log("DESTROY");

    }

    public void LevelOneUpgrades()
    {
        if(PlayerVariables.Cash >= App.Model.Advanced_Model.Level1UpgradeCost && PlayerVariables.Oil >= App.Model.Advanced_Model.Level1UpgradeGas)
        {
            PlayerVariables.Cash -= App.Model.Advanced_Model.Level1UpgradeCost;
            PlayerVariables.Oil -= App.Model.Advanced_Model.Level1UpgradeGas;

            App.Model.Advanced_Model.UpgradeButton.interactable = true;
            App.Model.UI_Model.Level1Upgrades_Button.interactable = false;

        }

        
    }
}
