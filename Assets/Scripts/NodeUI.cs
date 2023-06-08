using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellPrice;
    public Button upgradeButton;



    private Node target;

    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable= true;
        }
        else
        {
            upgradeCost.text ="Maxed Out.";
            upgradeButton.interactable = false;
        }
        sellPrice.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
