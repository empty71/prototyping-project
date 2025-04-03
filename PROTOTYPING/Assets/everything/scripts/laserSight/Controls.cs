using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int speed; public float friction; public float lerpSpeed;
    private float xDeg;
    private float yDeg;
    public Quaternion fromRotation; 
    public Quaternion toRotation;
  
    
    private void Start()
    {
   
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xDeg -= Input.GetAxis("Mouse X") * speed * friction;

            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(0, xDeg, 0);

            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
        }
    }
}
