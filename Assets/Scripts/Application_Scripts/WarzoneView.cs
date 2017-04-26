using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarzoneView : WarzoneElement {

    //Building Views
    public AR_View AR_View;
    public SniperAcad_View SniperAcad_View;
    public CC_View CC_View;
    public MissileFactory_View MissileFactory_View;
    public Advanced_View Advanced_View;
    public Laser_Building_View Laser_Building_View;
    public Flame_Building_View Flame_Building_View;
   
    void Start()
    {
        AR_View = GetComponentInChildren<AR_View>();
        SniperAcad_View = GetComponentInChildren<SniperAcad_View>();
        CC_View = GetComponentInChildren<CC_View>();
        MissileFactory_View = GetComponentInChildren<MissileFactory_View>();
        Advanced_View = GetComponentInChildren<Advanced_View>();
        Laser_Building_View = GetComponentInChildren<Laser_Building_View>();
        Flame_Building_View = GetComponentInChildren<Flame_Building_View>();
    }
	
}
