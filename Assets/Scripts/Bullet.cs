using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public float explosionRadius=0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) //Means we hit the target.
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance ,5f);

        if (explosionRadius >= 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }


        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach ( Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
