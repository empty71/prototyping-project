using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton<T> : MonoBehaviour where T : singleton<T>
{
    int somevalue = 5;
    public int alsoSomeValue { get;}

    public static T Instance { get; private set; }


    private void Awake()
    {
        somevalue = 2;
        //alsoSomeValue = 2;

        Debug.Log(somevalue);

        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else if(Instance == null)
        {
            Instance = (T)this;
        }


    }
}
