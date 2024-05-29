using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HEnemyHealth : MonoBehaviour
{

    ParticleSystem hitParticles;
    public int startingHealth = 100;
    public int currentHealth;
    Animator anim;

    AudioSource audioS;

    bool isSinking = false;
    bool isDead = false;
    public float sinkSpeed = 2.5f;

    public int score = 10;

    void Start()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;

        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead) return;

        audioS.Play();

        currentHealth -= damage;
        hitParticles.transform.position = hitPoint;

        hitParticles.Stop();
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        ScoreManage.Score += score;
    }

    public void StartSinking()
    {
        isSinking = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
