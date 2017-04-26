using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : WarzoneElement {

    private Renderer rend;
    public Color hoverColour;
    public Color errorColour;
    public Color startColour;
    private Color oldColour;

    [Header("Optional")]
    public GameObject Turret;
    public TurretBlueprint turretBlueprint;
    private TurretBlueprint tBlueprint;

    //Animation & Effects
    public GameObject SpawnFX;
    public GameObject UpgradeFX;
    public Texture NodeSkin; //still used?
    public Vector3 positionOffset;

    //State Properties
    public bool selected = false;
    private bool isUpgraded = false;
    public bool isActivated = false;

    //Singleton Instance
    BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
        //rend.material.mainTexture = NodeSkin;

    }

    public Vector3 GetBuildPos()
    {
        return this.transform.position;// + positionOffset;
    }

    public void ActivateNode()
    {
        //rend.material.color = errorColour;
        rend.material.EnableKeyword("_EMISSION");
        rend.material.SetColor("_EmissionColor", Color.cyan);
        isActivated = true;

    }


    void OnMouseDown()
    {
        App.Controller.BuildingViewReset();
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Turret != null)
        {

            BuildManager.instance.SetSelectedNode(this);
            

            return;
        }

        if ( ! BuildManager.instance.CanBuild(this))
        {
            BuildManager.instance.SetSelectedNode(this);
            rend.material.color = errorColour;
            Debug.Log("Cannot build there");
            return;

        }

        turretBlueprint = BuildManager.instance.GetBuildTurret();

        if (turretBlueprint == null)
            return;

        if(turretBlueprint.tag != "Pylon" && !isActivated)
        {
            return;
        }

        if (!BuildManager.instance.HasResources())
            return;
        else
            BuildTurret(turretBlueprint);
            oldColour = startColour;
            startColour = hoverColour;
            rend.material.color = hoverColour;

    }

    void OnMouseEnter()
    {
        //Raise Platform
        transform.position = transform.position + new Vector3(0, .55f, 0);
        if(this.Turret != null)
        {
            this.Turret.transform.position = this.Turret.transform.position + new Vector3(0, .55f, 0);
        }
        

        if (BuildManager.instance.CanBuild(this) && this.isActivated)
            {
            tBlueprint = BuildManager.instance.GetBuildTurret();

            if (tBlueprint == null)
            {
                return;

            }else if (tBlueprint.ps > (PlayerVariables.PsCap-PlayerVariables.PowerSupply))
            {
                rend.material.color = Color.yellow;
                return;

            }else if (BuildManager.instance.turretSelected())
            {
                rend.material.color = hoverColour;
                BuildManager.instance.PreviewRange(this);
            }
        }
            
        else if (BuildManager.instance.CanBuild(this) && !isActivated)
        {
            tBlueprint = BuildManager.instance.GetBuildTurret();

            if(tBlueprint == null)
            {
                return;
            }

            if(tBlueprint.tag == "Pylon")
            {
                rend.material.color = hoverColour;
            } else
            {
                rend.material.color = Color.red;
            }

        }
        //}       

        

        
    }

    void OnMouseExit()
    {
        //Raise Platform
        transform.position = transform.position - new Vector3(0, .55f, 0);
        //BuildManager.instance.HideRange();

        if (this.Turret != null)
        {
            this.Turret.transform.position = this.Turret.transform.position - new Vector3(0, .55f, 0);
        } 
              
        //else
        rend.material.color = startColour;

        //if(BuildManager.instance.CanBuild(this) && BuildManager.instance.selectedNode == null)
        //BuildManager.instance.HideRange();
    }

    public void ToggleSelcted()
    {

    }

    public void SellTurret()
    {
        rend.material.color = errorColour;
        PlayerVariables.Cash += 100;
        Destroy(this.Turret);
        turretBlueprint = null;

        //GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);

        //Reset Node Colour
        startColour = oldColour;
        rend.material.color = startColour;
        
    }

    public void UpgradeTurret()
    {
        if (PlayerVariables.Cash < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough cash to upgrade");
            return;
        }

        PlayerVariables.Cash -= turretBlueprint.upgradeCost;

        //Destroy old turret
        Destroy(Turret);

        if (turretBlueprint.prefab.tag == "Sniper")
        {
            GameObject turret = Instantiate(turretBlueprint.upgradePrefab, transform.position + positionOffset+ new Vector3(0,.75f,0), transform.rotation);
            Turret = turret;
            
        } else
        {
            //Build a new one
            GameObject _turret = Instantiate(turretBlueprint.upgradePrefab, this.transform.position, Quaternion.identity);
            Turret = _turret;

        }

        //Spawn Buff Upgrade Effect
        GameObject spawnEffect = Instantiate(SpawnFX, transform.position, SpawnFX.transform.rotation);
        Destroy(spawnEffect, 4f);
        Shop_Controller.controller.UIReset();
        isUpgraded = true;

    }

    public void BuildTurret(TurretBlueprint turretBlueprint)
    {

        if (turretBlueprint != null)
        {
            if (PlayerVariables.Cash < turretBlueprint.cost)
            {
                Debug.Log("Addition resources required");
                return;
            }

            if ((PlayerVariables.PowerSupply + turretBlueprint.ps) > PlayerVariables.PsCap)     //Change to can build call
            {
                Debug.Log("Addition power required");
                Debug.Log("PSC: " + PlayerVariables.PsCap.ToString());
                Debug.Log("PS: " + PlayerVariables.PowerSupply.ToString());
                return;
            }

            PlayerVariables.Cash -= turretBlueprint.cost;
            BuildManager.instance.cashText.text = PlayerVariables.Cash.ToString();

            PlayerVariables.PowerSupply += turretBlueprint.ps;
            BuildManager.instance.psText.text = PlayerVariables.PowerSupply.ToString() + "/" + PlayerVariables.PsCap;



            if (turretBlueprint.prefab.tag == "boost")
            {
                GameObject turret = Instantiate(turretBlueprint.prefab, this.transform.position, Quaternion.Euler(90, 0, 0));
                this.Turret = turret;
                Shop_Controller.controller.UIReset();

            }
            else if (turretBlueprint.prefab.tag == "Sniper")
            {
                GameObject turret = Instantiate(turretBlueprint.prefab, transform.position + positionOffset, transform.rotation);
                Turret = turret;
                Shop_Controller.controller.UIReset();
            }
            else
            {
                GameObject turret = Instantiate(turretBlueprint.prefab, transform.position, transform.rotation);
                Turret = turret;
                Shop_Controller.controller.UIReset();
            }

            //Spawn Hexagon Build Effect
            GameObject spawnEffect = Instantiate(SpawnFX, transform.position, SpawnFX.transform.rotation);
            Destroy(spawnEffect, 4f);

            rend.material.color = hoverColour;
            BuildManager.instance.SetBuildTurret(null);
        }



    }




    }
