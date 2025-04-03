using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject gunbarrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(gunbarrel.transform.position, gunbarrel.transform.forward, out hit))
        {
            if(hit.collider.tag== "Enemy")
            {
                Debug.Log("hit :" + hit.collider.gameObject.name);
            }
        }
    }

}
