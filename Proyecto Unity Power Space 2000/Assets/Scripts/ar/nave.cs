using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave : MonoBehaviour {

    public GameManagerScript manager;
    public float dannoAsteroide;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "asteroides")
        {
            manager.ReducirVida(dannoAsteroide);
        }
    }
}
