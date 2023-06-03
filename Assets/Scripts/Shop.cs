using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret ()
    {
        Debug.Log("Standart turret purchased!");
        buildManager.SelectTurretToBuild(standartTurret);    
    }
    //public void SelectAnotherTurret()
    //{
    //    Debug.Log("Another turret purchased!");
    //    buildManager.SelectTurretToBuild();
    //}
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}
