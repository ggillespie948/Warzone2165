using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFactory_View : WarzoneElement {

    // Use this for initialization
    void Start()
    {
        //Used to disable object upon game load
        if (!PlayerVariables.hasMissileFactory)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            App.Controller.BuildingViewReset();
        }

    }

    void OnMouseEnter()
    {
        App.Controller.MissileFactory_Controller.ShowHighlight();

    }

    void OnMouseExit()
    {
        if (!App.Model.MissileFactory_Model.UI.activeSelf)
            App.Controller.MissileFactory_Controller.HideHighlight();
    }

    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        App.Controller.MissileFactory_Controller.ShowUI();
        App.Controller.MissileFactory_Controller.ShowHighlight();
    }
}
