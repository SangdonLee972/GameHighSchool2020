﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;

    public float m_ClimbSpeed =2f;
    public float m_XAxisSpeed = 5f;
    public float m_YAxisSpeed = 5f;
    public float m_YJumpPower = 500f;
    bool Climp = false;
    bool Die = false;
    public int m_JumpCount = 0;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        if(Climp)
        {
            velocity.y = yAxis * m_ClimbSpeed;
        }
        m_Rigidbody2D.velocity = velocity;

        if (!Climp)
        {
            var animator = GetComponent<Animator>();
            animator.SetFloat("VelocityX", Mathf.Abs(xAxis));
            animator.SetFloat("VelocityY", velocity.y);
        }

        if (xAxis > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (xAxis < 0)
            transform.localScale = new Vector3(-1, 1, 1);


        if (Input.GetKeyDown(KeyCode.UpArrow) && m_JumpCount <= 0 && Climp == false)
        {
            m_Rigidbody2D.AddForce(Vector3.up
                * m_YJumpPower);

            m_JumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            var item = collision.GetComponent<ItemComponet>();
            if (item != null)
                item.BeAte();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        
            if (Climp)
            {
                Climp = false;
                m_Rigidbody2D.gravityScale = 3.5f;
                var animators = GetComponent<Animator>();
                animators.SetBool("Climp", false);
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Ladder" && Input.GetKeyDown(KeyCode.Space))
            
            if(!Climp)
            {
                Climp = true;
                m_Rigidbody2D.gravityScale = 0.1f;
                var animators = GetComponent<Animator>();
                animators.SetBool("Climp", true) ;
            }

        if(collision.tag == "Enemie")
        {
            if(!Die)
            {
                Die = true;
                var animators = GetComponent<Animator>();
                animators.SetBool("Die", true);
            }
        }
    }


}