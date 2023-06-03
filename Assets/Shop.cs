using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurschaseStandartTurret ()
    {
        Debug.Log("Standart turret purchased!");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);    
    }
    public void PurschaseAnotherTurret()
    {
        Debug.Log("Another turret purchased!");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

}
