using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspector : MonoBehaviour {

    //Singleton pattern
    public static Inspector instance;

    public TurretBlueprint TurretBlueprint;
    public GameObject TurretInstance;

    public GameObject Node;


    //Text
    public Text Name;
    public Text HP;
    public Text Description;
    public Text Level;
    public Text Type;
    public Text Shield;
    public Text Kills;

    //Buttons
    public Button Sell;
    public Button Upgrade;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public void InspectObject(GameObject Selected)
    {
        if (Selected.tag == null)
        {
            return;
        } else
        {
            if(Selected.tag == "Building")
            {

            } else if (Selected.tag == "SomethingMaybe?")
            {

            } else
            {
                InspectTurret();

            }

        }

    }

    public void InspectTurret()
    {


        Name.text = TurretBlueprint.ToString();
        //Level.text = TurretInstance.GetComponent<Turret>().level.ToString();
        //Kills.text = TurretInstance.GetComponent<Turret>().kills.ToString();
        GameObject.Find("SellButton").GetComponentInChildren<Text>().text = "SELL: " + (TurretBlueprint.cost / 2).ToString();

    }

    private void InspectBuilding()
    {

    }


}
