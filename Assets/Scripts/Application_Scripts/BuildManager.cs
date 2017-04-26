using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    //Singleton pattern
    public static BuildManager instance;

    //public shop Shop;
    public NodeUI nodeUI;

    private TurretBlueprint buildTurret;
    public Node selectedNode;

    public Text cashText;
    public Text psText;

    //Effects
    public GameObject sellEffect;
    public GameObject buildEffect;


    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Multiple Build Managers");   
        }
        instance = this;

    }

    void Start()
    {
        buildTurret = null;
        cashText.text = PlayerVariables.Cash.ToString();

    }

    void Update()
    {
        cashText.text = PlayerVariables.Cash.ToString();
    }

    public bool CanBuild(Node node)
    {
        if(node.Turret != null)
        {
            return false;
        } else
        {
            return true;
        }
    }

    public bool HasResources()
    {
        if(PlayerVariables.Cash >= buildTurret.cost && (PlayerVariables.PowerSupply + buildTurret.ps) <= PlayerVariables.PsCap)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool turretSelected()
    {
        if (buildTurret != null)
        {
            return true;
        }

        return false;
    }

    public void SetBuildTurret(TurretBlueprint turret)
    {
        buildTurret = turret;
        selectedNode = null;
        nodeUI.HideUI();
        return;

    }

    public TurretBlueprint GetBuildTurret()
    {
        return this.buildTurret;
    }

    public Node GetSelectedNode()
    {
        return this.selectedNode;
    }

    public void SetSelectedNode(Node node)
    {

        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        

        buildTurret = null;
        this.selectedNode = node;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        
        selectedNode = null;
        nodeUI.HideUI();
        
        
    }

    public void PreviewRange(Node node)
    {
        nodeUI.RangePreview(node, buildTurret);

        
    }

    public void HideRange()
    {
        nodeUI.HideRangeIndicator();
    }

   

        
    } 

