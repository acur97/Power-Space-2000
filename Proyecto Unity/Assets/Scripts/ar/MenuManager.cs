using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text Equipo;

    public void VolverMenu()
    {
        //SceneManager.LoadScene();
    }

    public void Nave1()
    {
        StartCoroutine(Nav1());
        Equipo.text = "Equipo Rojo";
    }

    IEnumerator Nav1()
    {
        
        yield return new WaitForSeconds(0.5f);
        GameManagerScript.Nave = 1;
        Initiate.Fade("Game", Color.black, 0.5f);
    }

    public void Nave2()
    {
        StartCoroutine(Nav2());
        Equipo.text = "Equipo Azul";
    }

    IEnumerator Nav2()
    {
        yield return new WaitForSeconds(0.5f);
        GameManagerScript.Nave = 2;
        Initiate.Fade("Game", Color.black, 0.5f);
    }

    public void Nave3()
    {
        StartCoroutine(Nav3());
        Equipo.text = "Equipo Verde";
    }

    IEnumerator Nav3()
    {
        yield return new WaitForSeconds(0.5f);
        GameManagerScript.Nave = 3;
        Initiate.Fade("Game", Color.black, 0.5f);
    }

    public void Nave4()
    {
        StartCoroutine(Nav4());
        Equipo.text = "Equipo Blanco";
    }

    IEnumerator Nav4()
    {
        yield return new WaitForSeconds(0.5f);
        GameManagerScript.Nave = 4;
        Initiate.Fade("Game", Color.black, 0.5f);
    }

    public void Nave5()
    {
        StartCoroutine(Nav5());
        Equipo.text = "Equipo Amarillo";
    }

    IEnumerator Nav5()
    {
        yield return new WaitForSeconds(0.5f);
        GameManagerScript.Nave = 5;
        Initiate.Fade("Game", Color.black, 0.5f);
    }
}
