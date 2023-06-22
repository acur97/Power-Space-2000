using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolucion : MonoBehaviour {

    [Header("Resolucion anterior: 0.667f")]
    public float PorcentajeBajada = 0.667f;

    private float resW;
    private float resH;
    private float newResW;
    private float newResH;

    private static float SresW;
    private static float SresH;
    private static float SnewResW;
    private static float SnewResH;
    private float PorcentajeElegido;
    private float PorcentajeElegido2;

    private readonly string pref_graf_f = "GraficosFloat";
    private readonly string pref_graf_b = "Adaptativo";

    private void Awake()
    {
        resW = Screen.currentResolution.width;
        resH = Screen.currentResolution.height;

        SresW = resW;
        SresH = resH;

        if (!PlayerPrefs.HasKey(pref_graf_b) || PlayerPrefs.GetInt(pref_graf_b) == 1)
        {
            newResW = (resW * PorcentajeBajada);
            newResH = (resH * PorcentajeBajada);

            Screen.SetResolution(((int)newResW), ((int)newResH), true);
        }
        else
        {
            PorcentajeElegido2 = PlayerPrefs.GetFloat(pref_graf_f);

            newResW = (resW * PorcentajeElegido2);
            newResH = (resH * PorcentajeElegido2);

            Screen.SetResolution(((int)newResW), ((int)newResH), true);
        }
    }

    public static void NewResMaster(float porcentajeB)
    {
        SnewResW = (SresW * porcentajeB);
        SnewResH = (SresH * porcentajeB);

        Screen.SetResolution(((int)SnewResW), ((int)SnewResH), true);
    }
}
