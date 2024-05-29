using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlayerShoot : MonoBehaviour {

    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;

    Ray shootRay;
    int shootMask;
    RaycastHit shootHit;
    float timer;

    public float range = 100f; 
    public float timeBetweenLine = 0.15f;
    public int damage = 20;

    float effectsDisplayTime = 0.2f;

    AudioSource audioS;

    void Start()
    {
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        shootMask = LayerMask.GetMask("Shootable");
        audioS = GetComponent<AudioSource>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenLine)
        {
            Shoot();
        }

        if (timer >= timeBetweenLine * effectsDisplayTime)
        {
            gunLight.enabled = false;
            gunLine.enabled = false;
        }
    }


    void Shoot()
    {
        timer = 0f;
        gunLight.enabled = true;

        audioS.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        gunParticles.Stop();
        gunParticles.Play();

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootMask))
        {
            HEnemyHealth enemyHealth = shootHit.collider.GetComponent<HEnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
