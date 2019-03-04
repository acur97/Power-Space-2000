using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionMenu : MonoBehaviour {

    public float VelocidadRotacion;

    void Update ()
    {
        gameObject.transform.Rotate(0, VelocidadRotacion, 0);
	}
}
