using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Small : MonoBehaviour
{
    public float Speed = 3;
    void Update()
    {
        Vector3 velocity = transform.up * Speed;
        Vector3 movement = transform.up * Speed * Time.deltaTime;
        transform.position -= movement;

    }
}
