using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform m_StartPoint;
    public PlayerControloer m_Player;

    public Text m_ClearUI;
    public Text m_ScoreUI;

    public void GameStart()
    {
        
        // 출발 지점에서 플레이어가 스폰된다.
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.position;
        m_Player.transform.rotation = m_StartPoint.rotation;

        // 클리어 메세지가 보이지 않는다.
        m_ClearUI.gameObject.SetActive(false);
        

        // 게임 스코어가 보인다.
        m_ScoreUI.gameObject.SetActive(true);

    }

    public void GameClear()
    {

    }

    public void ReturnToStartPoint()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
