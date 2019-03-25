using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCat1Controller : MonoBehaviour {

    private GameManagerScript manager;

    private readonly string tag_finis = "Finish";
    private readonly string tag_naves = "naves";
    private readonly string tag_manager = "GameController";

    private void Awake()
    {
        transform.transform.localPosition = new Vector3(Random.Range(-10, 11), Random.Range(-7, 6.5f), Random.Range(-20, 20));
        manager = GameObject.FindGameObjectWithTag(tag_manager).GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag_finis)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == tag_naves)
        {
            manager.ReducirVida(10);
        }
    }
}
