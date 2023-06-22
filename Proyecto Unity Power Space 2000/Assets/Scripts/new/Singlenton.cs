using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlenton : MonoBehaviour {

    private object[] single;

    private void Awake()
    {
        single = FindObjectsOfType(typeof(Singlenton));
        int len = single.Length;
        if (len == 2)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
