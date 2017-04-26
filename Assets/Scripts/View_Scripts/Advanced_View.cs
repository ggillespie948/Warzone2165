using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanced_View : WarzoneElement {

	// Use this for initialization
	void Start () {
        //Used to disable object upon game load
        if (!PlayerVariables.hasADV)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
	
	void OnMouseEnter()
    {
        App.Controller.Advanced_Controller.ShowHighlight();

    }

    void OnMouseExit()
    {
        if (!App.Model.Advanced_Model.UI.activeSelf)
            App.Controller.Advanced_Controller.HideHighlight();
    }

    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        App.Controller.Advanced_Controller.ShowUI();
        App.Controller.Advanced_Controller.ShowHighlight();
    }
}
