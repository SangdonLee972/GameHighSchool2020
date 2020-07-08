using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControloer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody m_Rigidbody;

    public float m_Speed = 25f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = /* GameObject.*/ GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * 10);

        
    }
}
