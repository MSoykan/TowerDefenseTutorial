using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex=0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position , target.position) <= .4f)
        {
            GetNextWayPoint();
        }
        
    }

    private void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }
}
