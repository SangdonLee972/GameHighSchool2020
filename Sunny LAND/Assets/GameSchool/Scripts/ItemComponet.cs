using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ItemComponet : MonoBehaviour
{
    public UnityEvent m_BeAteEvent;
    public void BeAte()
    {
        //아이템 이벤트 처리
        m_BeAteEvent.Invoke();
        
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
