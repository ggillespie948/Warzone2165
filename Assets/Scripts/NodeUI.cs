using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : WarzoneElement {

    //singleton pattern
    public static NodeUI Node_UI;

    public GameObject UI;
    public GameObject RangeIndicator;
    public GameObject UICanvas;
    public Button UpgradeButton;

    private Node target;

    public Text sellText;
    public Text upgradeText;
    private Turret t1;

    public void SetTarget(Node t)
    {
        target = t;
        transform.position = target.GetBuildPos();
        RangeIndicator.transform.position = target.GetBuildPos();
        t1 = t.Turret.GetComponent<Turret>();
        RangeIndicator.transform.localScale = new Vector3((int)t1.range*2, 0.2f, (int)t1.range*2);

        int sellCost = target.turretBlueprint.cost / 2;
        sellText.text = "Sell $" + sellCost;
        upgradeText.text = "Upgrade $" + target.turretBlueprint.upgradeCost;
        UI.SetActive(true);
        UICanvas.SetActive(true);
        RangeIndicator.SetActive(true);
    }

    public void RangePreview(Node target, TurretBlueprint tt)
    {
        RangeIndicator.transform.position = target.GetBuildPos();
        RangeIndicator.transform.localScale = new Vector3((int)tt.baseRange * 2, 1, (int)tt.baseRange * 2);
        UI.SetActive(true);
        UICanvas.SetActive(false);
        RangeIndicator.SetActive(true);
    }

    public void HideUI()
    {
        UI.SetActive(false);
        
    }

    public void HideRangeIndicator()
    {
        RangeIndicator.SetActive(false);
    }

    public void SellTurret()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();

    }

    public void UpgradeTurret()
    {
        target.UpgradeTurret();
        HideUI();
    }

    public void UnlockUpgrades()
    {
        UpgradeButton.interactable = true;
    }

}
