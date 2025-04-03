using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examplescript : MonoBehaviour
{
    private int number = 1;
    public int number2 = 1;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            number++;
        }

        if(number == 1)
        {
            Debug.Log("the number is 1");
        }
        else
        {
            Debug.Log("the number is " + number);
        }

    }
}
