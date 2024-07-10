using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    GameObject model;
    public bool canMove;

    public float speed;
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        model = GameObject.FindWithTag("PlayerModel");
        anim = GameObject.FindWithTag("PlayerModel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(x * speed,rb.velocity.y,z * speed);

        if (x != 0 || z != 0)
        {
            float targetAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            model.transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

        anim.SetFloat("Speed", Mathf.Abs(x)+Mathf.Abs(z));
    }
    public void Freeze()
    {
        canMove=false;
    }
}
