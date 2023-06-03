using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;
    public GameObject missileLauncherPrefab;




    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
            instance = this;
    }

    private TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }


    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build selected turret!");
            return;
        }
        PlayerStats.money -= turretToBuild.cost;

        GameObject turret  = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret built! Money left "+ PlayerStats.money);
    }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
