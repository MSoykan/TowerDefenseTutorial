using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Renderer rend;
    public Color startColor;
    [HideInInspector]
    public  GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())  
            return;


        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (buildManager.CanBuild == false)
        {
            return;
        }
        //buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
        // build turret
    }

    void BuildTurret(TurretBlueprint turretToBuild)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build selected turret!");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;

        GameObject _turret = (GameObject)Instantiate(turretToBuild.prefab, this.GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = turretToBuild;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret built!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }
        PlayerStats.money -= turretBlueprint.cost;

        //Get rid of the old turret
        Destroy(turret);

        //Building a new one


        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, this.GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, this.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded = true;
        Debug.Log("Turret upgraded!");
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild == false)
            return;

        if (buildManager.HasMoney)
        {
        rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
