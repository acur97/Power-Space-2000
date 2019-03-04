using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float VelocidadDisparo;

    private GameManagerScript manager;
    private Rigidbody esteRigi;

    private readonly string tag_enemiCat1 = "enemiCat1";
    private readonly string tag_enemiCat2 = "enemiCat2";

    private void Awake()
    {
        esteRigi = GetComponent<Rigidbody>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerScript>();
    }

    private void OnEnable()
    {
        StartCoroutine(Muerte());
    }

    private void FixedUpdate()
    {
        esteRigi.velocity = transform.forward * VelocidadDisparo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag_enemiCat1)
        {
            manager.AumentarPuntos(50);
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == tag_enemiCat2)
        {
            manager.AumentarPuntos(100);
            gameObject.SetActive(false);
        }
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
