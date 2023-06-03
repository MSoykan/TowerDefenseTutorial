using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWayPoint();
        }

    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);

    }
}
