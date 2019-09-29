﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBirdController : MonoBehaviour
{

    private bool isPressed = false;
    public float maxDis = 3f;
    private SpringJoint2D sj;
    private Rigidbody2D rb;

    public LineRenderer right;
    public LineRenderer left;
    public Transform rightPos;
    public Transform leftPos;


    private void Start()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // When you hold down the mouse
    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    //When you release the mouse
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        Invoke("Fly", 0.1f);


    }

    private void Update()
    {
        if (isPressed)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;

                transform.position = pos + rightPos.position;
            }

            //judge if springjoint2D is exist.
            slingshotLine();
              
        }
        
    }


    void Fly()
    {
        sj.enabled = false;//springjoint2D shihuo, because bird flies very quickly.
    }

    void slingshotLine()
    {
        right.SetPosition(0,rightPos.position);
        right.SetPosition(1,transform.position);

        left.SetPosition(0,leftPos.position);
        left.SetPosition(1,transform.position);


    }
}