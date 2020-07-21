using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool Istrue = false;
    public float Speed = 1;
    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = transform.up * Speed;
        Vector3 movement = transform.up * Speed * Time.deltaTime;
        transform.position += movement;
        

    }
}
