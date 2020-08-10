using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedCubeScripts : MonoBehaviour
{
    public float m_Speed = 5;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var movemnet = Vector3.down * m_Speed * Time.deltaTime;
        transform.position += movemnet;
    }

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        GameManager.Instance.AddScore();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plane")
        {
            Destroy(gameObject);
            GameManager.Instance.DamageLife();
        }
    }
}
