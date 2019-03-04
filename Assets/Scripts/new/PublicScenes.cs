using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicScenes : MonoBehaviour
{
    private readonly string s_exit = "Exit";
    private readonly string s_menuplay = "MenuPlay";
    private readonly string s_menugaraje = "MenuGaraje";
    private readonly string s_cargando1 = "Cargando1";
    private readonly string s_game = "Game";
    private int len;

    public bool TieneCanvasExit = true;
    public GameObject CanvasExit;
    public bool TieneOtrosCanvas = false;
    public GameObject[] OtrosCanvas;

    private void Awake()
    {
        if (TieneOtrosCanvas)
        {
            len = OtrosCanvas.Length;
        }
    }

    private void Update()
    {
        if(TieneCanvasExit == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CanvasExit.SetActive(true);

                Time.timeScale = 0;
                if (TieneOtrosCanvas == true)
                {
                    for (int i = 0; i < len; i++)
                    {
                        OtrosCanvas[i].SetActive(false);
                    }
                }
            }
        }
        
    }

    public void Pausa()
    {
        CanvasExit.SetActive(true);

        Time.timeScale = 0;
        if (TieneOtrosCanvas == true)
        {
            for (int i = 0; i < len; i++)
            {
                OtrosCanvas[i].SetActive(false);
            }
        }
    }

    public void Reanudar()
    {
        CanvasExit.SetActive(false);
        
        Time.timeScale = 1;
        if (TieneOtrosCanvas == true)
        {
            for (int i = 0; i < len; i++)
            {
                OtrosCanvas[i].SetActive(true);
            }
        }
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_exit, Color.white, 50);
    }

    public void GameReset()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_game, Color.grey, 1);
    }

    public void MenuPlay()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_menuplay, Color.black, 1);
    }

    public void MenuPlayDesdePausa()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_menuplay, Color.black, 1);
    }

    public void MenuGarajeConEspera(float espera)
    {
        Time.timeScale = 1;
        StartCoroutine(Pausa1(espera));
    }

    public void PerderAGaraje()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_menugaraje, Color.gray, 1);
    }

    IEnumerator Pausa1(float tt)
    {
        yield return new WaitForSeconds(tt);
        Initiate.Fade(s_menugaraje, Color.black, 1);
    }

    public void MenuGaraje()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_menugaraje, Color.black, 1);
    }

    public void Cargando1()
    {
        Time.timeScale = 1;
        Initiate.Fade(s_cargando1, Color.black, 1);
    }
}
