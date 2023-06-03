using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color startColor;
    public Vector3 positionOffset;

    private Renderer rend;
    [Header("Optional")]
    public  GameObject turret;

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
        if (buildManager.CanBuild == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }
        buildManager.BuildTurretOn(this);
        // build turret
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild == null)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
