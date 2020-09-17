using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropandDraw : MonoBehaviour
{
    public GameObject Selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform.CompareTag("Puzzle"))
            {
                Selected = hit.transform.gameObject;
            }
            else
            {
                print("A");
            }
        }
            if (Selected != null)
            {
                Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Selected.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Selected = null;
            }

    }
}
