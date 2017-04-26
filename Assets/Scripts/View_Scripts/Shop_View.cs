using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_View : MonoBehaviour {

	//public static Shop_View 
    
    // Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) && Shop_Model.model.b1.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret1();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha2) && Shop_Model.model.b2.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret2();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha3) && Shop_Model.model.b3.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret3();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha4) && Shop_Model.model.b4.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret4();
        }
        else
        if (Input.GetKeyUp(KeyCode.Alpha5) && Shop_Model.model.b5.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret5();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6) && Shop_Model.model.b6.IsInteractable())
        {
            Shop_Controller.controller.SelectTurret6();
        }
        else
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Shop_Controller.controller.UIReset();
            BuildManager.instance.SetBuildTurret(null);
            BuildManager.instance.SetSelectedNode(null);
        }
    }
}
