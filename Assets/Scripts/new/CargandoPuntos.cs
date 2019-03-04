using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargandoPuntos : MonoBehaviour {

    static readonly string no_puntos = "";
    static readonly string un_punto = ".";
    static readonly string dos_puntos = "..";
    static readonly string tres_puntos = "...";
    static readonly string cuatro_puntos = "....";

    public float Espera;
    public string EscenaACargar;

    private Text testo;

    private void Awake()
    {
        testo = GetComponent<Text>();
        StartCoroutine(CargandoAnim());
        StartCoroutine(CargarEscena());
    }

    private void Start()
    {
        testo.text = no_puntos;
    }

    IEnumerator CargandoAnim()
    {
        yield return new WaitForSeconds(0.5f);
        testo.text = un_punto;
        yield return new WaitForSeconds(0.5f);
        testo.text = dos_puntos;
        yield return new WaitForSeconds(0.5f);
        testo.text = tres_puntos;
        yield return new WaitForSeconds(0.5f);
        testo.text = cuatro_puntos;
        StartCoroutine(CargandoAnim());
    }

    IEnumerator CargarEscena()
    {
        yield return new WaitForSeconds(Espera);
        SceneManager.LoadSceneAsync(EscenaACargar);
    }
}
