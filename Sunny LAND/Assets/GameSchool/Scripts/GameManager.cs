using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ItemComponet> m_Items = new List<ItemComponet>();

    public GameObject m_GameClearUI;

    public GameObject m_Player;
    public Transform m_StartPoint;
    public FollowCamera m_JointArm;

    public bool m_IsPlaying;
    public VariableJoystick m_Joystick;
    public void GameStart()
    {
        var playerInstace = Instantiate(m_Player, m_StartPoint.position, m_StartPoint.rotation);
        m_JointArm.m_Target = playerInstace.transform;
        
    }

    public void Start()
    {
        GameStart();
    }

 

    void Update()
    {
        
    }
}
