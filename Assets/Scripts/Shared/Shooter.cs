using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    public Transform targetRaycast;

    public ParticleSystem shootEffect;
    public GameObject impactEffect;

    private Reloader reloader;

    public bool canFire;

    private void Awake()
    {
        reloader = GetComponent<Reloader>();
    }
    public virtual void Shoot()
    {
        canFire = false;
        if (Time.time >= nextTimeToFire)
        {
            if (reloader != null)
            {
                if (reloader.IsReloading)
                {
                    return;
                }
                if (reloader.BulletRemainingInClip == 0)
                {
                    return;
                }
                reloader.TakeFromClip(1);
            }
            nextTimeToFire = Time.time + 1f / fireRate;
            shootEffect.Play();
            RaycastHit hit;
            if (Physics.Raycast(targetRaycast.transform.position, targetRaycast.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Health enemy = hit.transform.GetComponent<Health>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            canFire = true;
            Destroy(impact, 2f);
        }        
    }

    public void Reload()
    {
        if (reloader == null)
        {
            return;
        }
        reloader.Reload();
    }
}
