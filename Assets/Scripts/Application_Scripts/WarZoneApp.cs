using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarzoneElement : MonoBehaviour
{
    public WarZoneApp App { get { return GameObject.FindObjectOfType<WarZoneApp>(); } }

}

public class WarZoneApp : MonoBehaviour
{
    //References to the Root Instances of MVC

    //MVC Root Instances
    public WarzoneView View;
    public WarzoneModel Model;
    public WarzoneController Controller;

    void Start()
    {


    }


}
