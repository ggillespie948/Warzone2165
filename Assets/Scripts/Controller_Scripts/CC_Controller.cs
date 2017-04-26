using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_Controller : WarzoneElement
{

    //Generic///////////////
    public void ShowUI()
    {
        App.Model.CC_Model.UI.SetActive(true);
    }

    public void HideUI()
    {
        App.Model.CC_Model.UI.SetActive(false);
    }

    public void ToggleUI()
    {
        if (App.Model.CC_Model.UI.activeSelf)
        {
            App.Model.CC_Model.UI.SetActive(false);
        }
        else
        {
            App.Model.CC_Model.UI.SetActive(true);
        }

    }

    public void ShowHighlight()
    {
        App.Model.CC_Model.Highlight.SetActive(true);
    }

    public void HideHighlight()
    {
        App.Model.CC_Model.Highlight.SetActive(false);
    }

    public void DamageBuilding(int dmg)
    {
        App.Model.CC_Model.Health--;

        if (App.Model.CC_Model.Health <= 0)
        {
            DestroyBuilding();
        }

    }

    public void RepairBuilding(int rpr)
    {


    }

    public void DestroyBuilding()
    {
        //Game Over Trigger

    }
    ////////////////////////


    //CC Actions///////////////
    public void UpgradePS()
    {
        Debug.Log("PS Upgraded");

        if (PlayerVariables.Cash >= 100)
        {
            PlayerVariables.Cash -= 100;
            PlayerVariables.PsCap += 25;
            App.Model.UI_Model.psText.text = PlayerVariables.PowerSupply.ToString() + "/" + PlayerVariables.PsCap;
        }
    }


    public void BuyPlanetry()
    {
        //CC_GUN.SetActive(true);

    }

    public void BuyAR()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.ArmoryCost && PlayerVariables.Oil >= App.Model.CC_Model.ArmoryGas && PlayerVariables.hasAR==false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.ArmoryCost;
            PlayerVariables.Oil -= App.Model.CC_Model.ArmoryGas;
            PlayerVariables.hasAR = true;

            App.Controller.AR_Controller.Activate();
            

        } else if (PlayerVariables.hasAR)
        {
            //Select AR;
        }

    }

    public void BuyAdv()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.AdvMunitionCost && PlayerVariables.Oil >= App.Model.CC_Model.AdvMunitionGas && PlayerVariables.hasADV == false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.AdvMunitionCost;
            PlayerVariables.Oil -= App.Model.CC_Model.AdvMunitionGas;
            PlayerVariables.hasADV = true;

            App.Controller.Advanced_Controller.Activate();


        }
        else if (PlayerVariables.hasADV)
        {
            //Select ADV;
        }

    }

    public void BuySniperAcademy()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.SniperAcademyCost && PlayerVariables.Oil >= App.Model.CC_Model.SniperAcademyGas && PlayerVariables.hasSniperAcademy == false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.SniperAcademyCost;
            PlayerVariables.Oil -= App.Model.CC_Model.SniperAcademyGas;
            PlayerVariables.hasSniperAcademy = true;

            App.Controller.SniperAcad_Controller.Activate();


        }
        else if (PlayerVariables.hasSniperAcademy)
        {
            //Select SA;
        }

    }

    public void BuyLaserFactory()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.LaserFactoryCost && PlayerVariables.Oil >= App.Model.CC_Model.LaserFactoryGas && PlayerVariables.hasLSR == false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.LaserFactoryCost;
            PlayerVariables.Oil -= App.Model.CC_Model.LaserFactoryGas;
            PlayerVariables.hasLSR = true;

            App.Controller.Laser_Controller.Activate();


        }
        else if (PlayerVariables.hasLSR)
        {
            //Select SA;
        }

    }

    public void BuyMissilePlant()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.MissilePlantCost && PlayerVariables.Oil >= App.Model.CC_Model.MissilePlantGas && PlayerVariables.hasMissileFactory == false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.MissilePlantCost;
            PlayerVariables.Oil -= App.Model.CC_Model.MissilePlantGas;
            PlayerVariables.hasMissileFactory = true;

            App.Controller.MissileFactory_Controller.Activate();


        }
        else if (PlayerVariables.hasMissileFactory)
        {
            //Select SA;
        }

    }

    public void BuyIncinerator()
    {
        if (PlayerVariables.Cash >= App.Model.CC_Model.IncineratorCost && PlayerVariables.Oil >= App.Model.CC_Model.IncineratorGas && PlayerVariables.hasFLM == false)
        {
            PlayerVariables.Cash -= App.Model.CC_Model.IncineratorCost;
            PlayerVariables.Oil -= App.Model.CC_Model.IncineratorGas;
            PlayerVariables.hasFLM = true;

            App.Controller.Flame_Controller.Activate();


        }
        else if (PlayerVariables.hasLSR)
        {
            //Select SA;
        }

    }

    public void BuyOilRefinary()
    {

    }

    public void BuyAdvancedRadar()
    {

    }
    ////////////////////////////




}
