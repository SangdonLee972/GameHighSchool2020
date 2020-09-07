using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform m_Target;

    public Vector3 m_Offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = m_Target.position + m_Offset;    
    }
}
