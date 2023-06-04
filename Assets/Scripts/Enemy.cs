using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float slowPercentage)
    {
        speed = startSpeed * (1f - slowPercentage);
    }

    private void Die()
    {
        PlayerStats.money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    
}
