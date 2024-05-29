using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float speed = 5f;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime * speed);
    }
}
