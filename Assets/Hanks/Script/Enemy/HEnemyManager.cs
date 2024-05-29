using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyManager : MonoBehaviour {

    public GameObject enemy;
    public float bornTime = 3f;
    public Transform bornPos;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Born", bornTime, bornTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Born()
    {
        Instantiate(enemy, bornPos.position, bornPos.rotation);
    }

}
