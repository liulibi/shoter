using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyAttack : MonoBehaviour {

    GameObject player;                          
    HPlayerHealth playerHealth;
    bool playerInRange;

    float timer;

    public int attackDamage = 10;
    public float attackTime = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HPlayerHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackTime && playerInRange)
        {
            Attack();
        }
    }


    void Attack()
    {
        timer = 0f;
        playerHealth.TakeDamage(attackDamage);
    }
}
