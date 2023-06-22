using System.Collections;
using UnityEngine;

public class Laser2 : MonoBehaviour {

    public float VelocidadDisparo;

    private GameManagerScript manager;
    private Rigidbody esteRigi;
    private Transform PuntoNave;
    private bool act;

    private readonly string tag_naves = "naves";
    private readonly string tag_punto = "PuntoNave";

    private void Awake()
    {
        esteRigi = GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
        PuntoNave = GameObject.FindGameObjectWithTag(tag_punto).transform;
        act = true;
    }

    private void OnEnable()
    {
        StartCoroutine(Muerte());
    }

    private void FixedUpdate()
    {
        esteRigi.velocity = transform.forward * VelocidadDisparo;
        if (act == true)
        {
            transform.LookAt(PuntoNave);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag_naves)
        {
            manager.ReducirVida(30);
            gameObject.SetActive(false);
        }
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSeconds(0.15f);
        act = false;
        yield return new WaitForSeconds(0.85f);
        gameObject.SetActive(false);
    }
}
