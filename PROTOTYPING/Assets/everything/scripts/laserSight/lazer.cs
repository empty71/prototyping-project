using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    private LineRenderer lr;

  
    float ypos = 0.5f;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
   
    }

    private void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, ypos,hit.distance));
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(0,ypos ,50));
        }
    }
}
