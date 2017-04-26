using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR_Controller : WarzoneElement {

    //Generic
    public void Activate()
    {
        App.View.AR_View.enabled = true;
        for (int i = 0; i < App.View.AR_View.transform.childCount; ++i)
        {
            App.View.AR_View.transform.GetChild(i).gameObject.SetActive(true);
        }

        App.Model.AR_Model.Highlight.SetActive(false);

        //Diasble AR  Purchase Button
        App.Model.UI_Model.AR_Button.interactable = false;
        App.Model.UI_Model.AR_Button.GetComponent<Image>().color = App.Model.CC_Model.ActiveTechnology;

        //Activate ADV and SniperAcad UI Elements
        App.Model.UI_Model.ADV_Button.interactable = true;
        App.Model.UI_Model.ADV_Button.GetComponentInChildren<Text>().color = App.Model.CC_Model.unlockedText;

        App.Model.UI_Model.SNP_Button.interactable = true;
        App.Model.UI_Model.SNP_Button.GetComponentInChildren<Text>().color = App.Model.CC_Model.unlockedText;

    }

    public void ShowUI()
    {
        App.Model.AR_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.AR_Model.UI.SetActive(false);
    }

    public void ShowHighlight()
    {
        App.Model.AR_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.AR_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.AR_Model.Health--;

        if (App.Model.AR_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {
        

    }

    public void DestroyBuilding()
    {
        //PlayerVariables.hasAR = false;
        //Destroy(App.View.AR_View.gameObject);

    }

    //AR_Specific
}
