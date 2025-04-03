using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstance : singleton<TestInstance>
{
    public string str;


    public void Hello()
    {
        Debug.Log("Hello World!");
    }
}
