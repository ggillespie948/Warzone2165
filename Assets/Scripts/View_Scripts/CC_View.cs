using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_View : WarzoneElement {

    // Use this for initialization
    void Start()
    {

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
        App.Controller.CC_Controller.ShowHighlight();

    }

    void OnMouseExit()
    {
        if (!App.Model.CC_Model.UI.activeSelf)
            App.Controller.CC_Controller.HideHighlight();
    }

    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        App.Controller.CC_Controller.ShowUI();
        App.Controller.CC_Controller.ShowHighlight();
    }
}
