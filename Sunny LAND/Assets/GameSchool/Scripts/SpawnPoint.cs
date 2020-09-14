using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject m_MonsterPrefab;
    public GameObject m_MonsterInstance;

    public float m_SpawnTimer = 10f;
    public bool m_IsStayPlayer;

    // Update is called once per frame

    public void Update()
    {
        if(m_IsStayPlayer)
        {
            m_SpawnTimer += Time.deltaTime;
            if (m_SpawnTimer >= 5f)
            {
                //if(m_MonsterInstance==null)
                ////{
                //    m_MonsterInstance = GameObject.Instantiate(m_MonsterPrefab, transform.position, transform.rotation);
                //}

                SpawnMonster();
                m_SpawnTimer = 0;
            }
            else
            {
                m_SpawnTimer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            SpawnMonster();
            m_IsStayPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.attachedRigidbody.tag=="Player")
        {
            m_IsStayPlayer = false;
        }
    }


    public Vector3 m_PatrolOffset;

    private void SpawnMonster()
    {
        if (m_MonsterInstance == null)
        {
            m_MonsterInstance = GameObject.Instantiate(m_MonsterPrefab,
                transform.position, transform.rotation);

            var flyPatrol = m_MonsterInstance.GetComponent<EnemieMove>();
            flyPatrol.m_PatrolOffset = m_PatrolOffset;
            flyPatrol.ResetPatrolPos();
        }
    }


}
