using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComandCentre : MonoBehaviour {

    public GameObject CC_UI;
    public GameObject CC_Highlight;

    public Text psText;
    public Text oilText;


    //TEMP
    public GameObject CC_GUN;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CC_UI.SetActive(false);
        }
        
    }
	
    void OnMouseDown()
    {
        Debug.Log("Comand Centre click!!!");
        CC_UI.SetActive(true);
        
    }

    void OnMouseEnter()
    {
        CC_Highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        if(!CC_UI.activeSelf)
        CC_Highlight.SetActive(false);
    }

    public void UpgradePowerSupply()
    {
        Debug.Log("PS Upgraded");

        if(PlayerVariables.Cash >= 100)
        {
            PlayerVariables.Cash -= 100;
            PlayerVariables.PsCap += 25;
            psText.text = PlayerVariables.PowerSupply.ToString() + "/" + PlayerVariables.PsCap;
        }
        
    }

    public void BuyPlanetry()
    {
        CC_GUN.SetActive(true);

    }

    public void ToggleUI()
    {
        if (CC_UI.activeSelf)
        {
            CC_UI.SetActive(false);
        }else
        {
            CC_UI.SetActive(true);
        }

    }

    public bool isUiActive()
    {
        return CC_UI.activeSelf;
    }

    


}
