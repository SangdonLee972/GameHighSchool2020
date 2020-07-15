using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_player;

    public bool isground = false;
    public bool isdaed = false;
    public int jumpCount = 0;

    public AudioSource m_AudioSource;
    public AudioClip m_Jump;
    public AudioClip m_Die;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            isground = !isground;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            isdaed = !isdaed;
        if (Input.GetKey(KeyCode.A))
        {
            m_player.position += new Vector2(-2, 0) * Time.deltaTime;
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_player.position += new Vector2(2, 0) * Time.deltaTime;
            transform.localScale = new Vector2(1, 1);

        }


        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            m_player.velocity = Vector2.zero;
            m_player.AddForce(Vector2.up * 300);
            jumpCount++;

            m_AudioSource.clip = m_Jump;
            m_AudioSource.Play();
        }

        m_Animator.SetBool("IsDie", isdaed);
        m_Animator.SetBool("IsGround", isground);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            jumpCount = 0;
            isground = true;
        }
    }


  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isground = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {

            isdaed = true;
            m_Animator.SetBool("IsDie", isdaed);
            m_AudioSource.clip = m_Die;
            m_AudioSource.Play();
        }
    }

}