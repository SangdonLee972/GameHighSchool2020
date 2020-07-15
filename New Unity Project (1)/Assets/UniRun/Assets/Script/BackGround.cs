using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float width;

    // Update is called once per frame
    void Update()
    {  
        var collider = GetComponent<BoxCollider2D>();
        width = collider.size.x;

        if(transform.position.x <= -width)
        {
            transform.position += Vector3.right * width * 2;
        }
    }
}
