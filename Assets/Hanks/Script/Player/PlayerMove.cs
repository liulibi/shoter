using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 6f;
    Rigidbody playerRigidbody;
    int floorMask;
    float rayLength = 100f;

    Animator anim;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");

        anim = GetComponent<Animator>();
    }

    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Rotate()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(mouseRay, out floorHit, rayLength, floorMask))
        {
            Vector3 playerRotate = floorHit.point - transform.position;
            Quaternion rotate = Quaternion.LookRotation(playerRotate);
            playerRigidbody.MoveRotation(rotate);
        }
    }

    void Animating(float h, float v)
    {
        bool moving = (h != 0 || v != 0);
        anim.SetBool("IsMoving", moving);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Rotate();
        Animating(h, v);
    }
}
