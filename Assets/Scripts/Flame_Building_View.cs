using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Building_View : WarzoneElement {

    // Use this for initialization
    void Start()
    {
        //Used to disable object upon game load
        if (!PlayerVariables.hasFLM)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    void OnMouseEnter()
    {
        App.Controller.Flame_Controller.ShowHighlight();

    }

    void OnMouseExit()
    {
        if (!App.Model.Flame_Building_Model.UI.activeSelf)
            App.Controller.Flame_Controller.HideHighlight();
    }

    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        App.Controller.Flame_Controller.ShowUI();
        App.Controller.Flame_Controller.ShowHighlight();
    }
}
