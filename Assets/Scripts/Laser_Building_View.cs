using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Building_View : WarzoneElement {

	// Use this for initialization
	void Start () {
        //Used to disable object upon game load
        if (!PlayerVariables.hasLSR)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
	
	void OnMouseEnter()
    {
        App.Controller.Laser_Controller.ShowHighlight();

    }

    void OnMouseExit()
    {
        if (!App.Model.Laser_Building_Model.UI.activeSelf)
            App.Controller.Laser_Controller.HideHighlight();
    }

    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        App.Controller.Laser_Controller.ShowUI();
        App.Controller.Laser_Controller.ShowHighlight();
    }
}
