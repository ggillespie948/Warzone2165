using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarzoneController : WarzoneElement
{
    //Building_Controller
    public AR_Controller AR_Controller;
    public SniperAcad_Controller SniperAcad_Controller;
    public CC_Controller CC_Controller;
    public MissileFactory_Controller MissileFactory_Controller;
    public Advanced_Controller Advanced_Controller;
    public Laser_Controller Laser_Controller;
    public Flame_Controller Flame_Controller;
    //Node_Controller


    //Shop_Controler ** Uses singleton patter right now so doesn't need to be linked to overhead



    void Start()
    {
        AR_Controller = GetComponentInChildren<AR_Controller>();
        SniperAcad_Controller = GetComponentInChildren<SniperAcad_Controller>();
        CC_Controller = GetComponentInChildren<CC_Controller>();
        MissileFactory_Controller = GetComponentInChildren<MissileFactory_Controller>();
        Advanced_Controller = GetComponentInChildren<Advanced_Controller>();
        Laser_Controller = GetComponentInChildren<Laser_Controller>();
        Flame_Controller = GetComponentInChildren<Flame_Controller>();
    }

    public void BuildingViewReset()
    {
        AR_Controller.HideUI();
        AR_Controller.HideHighlight();

        SniperAcad_Controller.HideUI();
        SniperAcad_Controller.HideHighlight();

        CC_Controller.HideUI();
        CC_Controller.HideHighlight();

        MissileFactory_Controller.HideUI();
        MissileFactory_Controller.HideHighlight();

        Advanced_Controller.HideUI();
        Advanced_Controller.HideHighlight();
    }
	
}
