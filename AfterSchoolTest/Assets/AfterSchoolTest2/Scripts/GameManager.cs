using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int m_life = 3;
    public int m_score = 0;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        
    }

    public void AddScore()
    {
        m_score++;
    }

    public void DamageLife()
    {
        m_life--;
        if(m_life <=0)
        {
            //gameover;
        }
    }
}
