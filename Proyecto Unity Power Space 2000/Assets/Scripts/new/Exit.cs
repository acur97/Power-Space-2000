using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    private readonly string c_dos = "C:";
    private readonly string raya_baja = " _";
    private GameObject unic;

    public float espera;
    public string rayita;

    public Text testo;

    private void Awake()
    {
        unic = GameObject.Find("_Unico");
        Destroy(unic);
    }

    void Start ()
    {
        StartCoroutine(raya());
        StartCoroutine(chao());
	}

    IEnumerator raya()
    {
        yield return new WaitForSeconds(0.3f);
        testo.text = c_dos + rayita;
        yield return new WaitForSeconds(0.3f);
        testo.text = c_dos + rayita + raya_baja;
        StartCoroutine(raya());
    }

    IEnumerator chao()
    {
        yield return new WaitForSeconds(espera);
        Application.Quit();
    }
}
