using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarzoneModel : WarzoneElement {

    //References to every used model

    //Shop Model
    public Shop_Model Shop_Model;

    //UI Model
    public UI_Model UI_Model;

    //Buildings
    public AR_Model AR_Model;
    public SniperAcad_Model SniperAcad_Model;
    public CC_Model CC_Model;
    public MissileFactory_Model MissileFactory_Model;
    public Advanced_Model Advanced_Model;
    public Laser_Building_Model Laser_Building_Model;
    public Flame_Building_Model Flame_Building_Model;

    //Turrets

    void Start()
    {
        Shop_Model = GetComponentInChildren<Shop_Model>();

        UI_Model = GetComponentInChildren<UI_Model>();

        AR_Model = GetComponentInChildren<AR_Model>();
        SniperAcad_Model = GetComponentInChildren<SniperAcad_Model>();
        CC_Model = GetComponentInChildren<CC_Model>();
        MissileFactory_Model = GetComponentInChildren<MissileFactory_Model>();
        Advanced_Model = GetComponentInChildren<Advanced_Model>();
        Laser_Building_Model = GetComponentInChildren<Laser_Building_Model>();
        Flame_Building_Model = GetComponentInChildren<Flame_Building_Model>();
    }

}
