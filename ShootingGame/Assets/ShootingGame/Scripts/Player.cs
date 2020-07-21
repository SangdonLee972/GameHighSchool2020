using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_Speed = 1f;
    public Bullet m_BulletPrefab;
    public float m_AttackDelay = 0.5f;
    public float m_AttackCooldown = 0f;

    public Transform[] m_FireMuzzles;

    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 inputValue = new Vector2(xAxis, yAxis).normalized;
        Vector3 movement = inputValue * m_Speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && m_AttackCooldown <=0)
        {
            foreach(var fireMuzzle in m_FireMuzzles)
            {
                var bullet = GameObject.Instantiate(m_BulletPrefab,
                fireMuzzle.position, fireMuzzle.rotation);
            }
            m_AttackCooldown = m_AttackDelay;
        }
        m_AttackCooldown -= Time.deltaTime;
    }
}
