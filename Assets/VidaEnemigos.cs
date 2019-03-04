using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour {
    
    private GameManagerScript manager;

    public int vidaEnemigo;
    public GameObject Afterburner;
    public GameObject PuntoDisparo;
    public GameObject BAKE;
    public int BumMalosNumero;

    private readonly string tag_explo = "BumMalos";
    private readonly string tag_explo2 = "BumMalos2";
    private readonly string tag_Bala = "Bala";
    private readonly string tag_finis = "Finish";
    private readonly string tag_manager = "GameController";

    private int DannoBala;

    private void Awake()
    {
        DannoBala = GameManagerScript.DanoBalas;
        manager = GameObject.FindGameObjectWithTag(tag_manager).GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag_Bala)
        {
            BajarVida();
        }
        if (other.gameObject.tag == tag_finis)
        {
            Destruir();
        }
    }

    void Destruir()
    {
        Destroy(gameObject);
        Destroy(Afterburner);
        Destroy(PuntoDisparo);
        Destroy(BAKE);
    }

    void BajarVida()
    {
        vidaEnemigo = vidaEnemigo - DannoBala;
        if (vidaEnemigo == 0)
        {
            if (BumMalosNumero == 1)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(tag_explo);
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                    Destroy(gameObject);
                    Destroy(Afterburner);
                    Destroy(PuntoDisparo);
                    Destroy(BAKE);
                    manager.AumentarPuntos(10);
                }
            }
            if (BumMalosNumero == 2)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(tag_explo2);
                if (bullet != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                    Destroy(gameObject);
                    Destroy(Afterburner);
                    Destroy(PuntoDisparo);
                    Destroy(BAKE);
                    manager.AumentarPuntos(10);
                }
            }
        }
    }
}
