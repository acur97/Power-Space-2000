using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public Text Puntaje;
    [Space]
    public GameObject Nave1;
    public GameObject Nave2;
    public GameObject Nave3;
    public GameObject Nave4;
    public GameObject Nave5;
    [Space]
    public Slider SliderVida;
    public Image SliderFill;
    public GameObject UIPlay;
    public GameObject UIMuerte;
    public Text FinalPuntaje;
    public Text FInalRecord;
    public GameObject CanvasInitialFade;
    public GameObject ExplocionNave;
    public GameObject BotonReward;
    [Space]
    public PublicScenes escenas;
    public VelocidadJugador velJugador;
    public Kino.DigitalGlitch glitch;
    public UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vignette;
    public UnityStandardAssets.ImageEffects.BloomOptimized blom;
    public UnityStandardAssets.ImageEffects.SunShafts sun;
    [Space]
    public GooglePlayOthers Gplay;

    public static int DanoBalas = 5;
    public static int Nave;

    private readonly string pref_record = "Record";
    private readonly string tex_textoNewRecord = "¡New record! ";
    private readonly string tex_textoOldRecord = "Current Record: ";

    private float puntos;
    private float life;
    private float speed;
    private float speed2 = 4;
    private float speed4 = 0.2f;

    [Space]
    public bool yaMiroReward = false;

    private void Awake()
    {
        if (Nave == 1)
        {
            Nave1.SetActive(true);
            Destroy(Nave2);
            Destroy(Nave3);
            Destroy(Nave4);
            Destroy(Nave5);
        }
        if (Nave == 2)
        {
            Destroy(Nave1);
            Nave2.SetActive(true);
            Destroy(Nave3);
            Destroy(Nave4);
            Destroy(Nave5);
        }
        if (Nave == 3)
        {
            Destroy(Nave1);
            Destroy(Nave2);
            Nave3.SetActive(true);
            Destroy(Nave4);
            Destroy(Nave5);
        }
        if (Nave == 4)
        {
            Destroy(Nave1);
            Destroy(Nave2);
            Destroy(Nave3);
            Nave4.SetActive(true);
            Destroy(Nave5);
        }
        if (Nave == 5)
        {
            Destroy(Nave1);
            Destroy(Nave2);
            Destroy(Nave3);
            Destroy(Nave4);
            Nave5.SetActive(true);
        }

        life = SliderVida.maxValue;
        SliderVida.value = SliderVida.maxValue;
        StartCoroutine(iniciaVelocidad());
        CanvasInitialFade.SetActive(true);
    }

    IEnumerator iniciaVelocidad()
    {
        velJugador.enabled = false;
        sun.enabled = false;
        yield return new WaitForSeconds(4);
        velJugador.enabled = true;
        sun.enabled = true;
        StartCoroutine(ChangeSpeed2(50, 4, 2));
        StartCoroutine(ChangeSpeed4(0, 0.2f, 2));
    }

    IEnumerator ChangeSpeed2(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed2 = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed2 = v_end;
    }

    IEnumerator ChangeSpeed4(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed4 = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed4 = v_end;
    }

    public void AumentarPuntos(float multiplicador)
    {
        puntos = puntos + (1 * multiplicador);
        Puntaje.text = puntos.ToString();
    }

    public void ReducirVida(float danno)
    {
        life = life - (1 * danno);
        StartCoroutine(ChangeSpeed3(8, 4, 1));
        SliderVida.value = life;
        if (life <= 718)
        {
            SliderFill.color = new Color32(128, 180, 75, 255);
        }
        if (life <= 286)
        {
            SliderFill.color = new Color32(255, 125, 75, 255);
        }
        if (life <= 143)
        {
            SliderFill.color = new Color32(255, 50, 25, 255);
        }
        if (life <= 47)
        {
            SliderFill.color = new Color32(255, 0, 0, 255);
        }
        if (life <= 1)
        {
            Perdio();
        }
    }

    IEnumerator ChangeSpeed3(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed2 = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed2 = v_end;
    }

    public void RevivirPorAnuncio()
    {
        life = SliderVida.maxValue;
        SliderVida.value = SliderVida.maxValue;

        UIPlay.SetActive(true);
        UIMuerte.SetActive(false);

        if (Nave == 1)
        {
            Nave1.SetActive(true);
        }
        if (Nave == 2)
        {
            Nave2.SetActive(true);
        }
        if (Nave == 3)
        {
            Nave3.SetActive(true);
        }
        if (Nave == 4)
        {
            Nave4.SetActive(true);
        }
        if (Nave == 5)
        {
            Nave5.SetActive(true);
        }
    }

    public void Perdio()
    {
        FinalPuntaje.text = puntos.ToString();
        if (yaMiroReward == false)
        {
            BotonReward.SetActive(true);
        }
        else
        {
            BotonReward.SetActive(false);
        }
        if (PlayerPrefs.HasKey(pref_record))
        {
            if (puntos > PlayerPrefs.GetFloat(pref_record))
            {
                PlayerPrefs.SetFloat(pref_record, puntos);
                FinalPuntaje.text = puntos.ToString();
                FInalRecord.text = tex_textoNewRecord + puntos.ToString();
                Gplay.PostearScoreBestAnyLevel((long)puntos);
            }
            else
            {
                FinalPuntaje.text = puntos.ToString();
                FInalRecord.text = tex_textoOldRecord + PlayerPrefs.GetFloat(pref_record).ToString();
            }
        }
        else
        {
            PlayerPrefs.SetFloat(pref_record, puntos);
            FinalPuntaje.text = puntos.ToString();
            FInalRecord.text = tex_textoNewRecord + puntos.ToString();
        }

        UIPlay.SetActive(false);
        UIMuerte.SetActive(true);
        ExplocionNave.SetActive(true);
        if (Nave == 1)
        {
            Nave1.SetActive(false);
        }
        if (Nave == 2)
        {
            Nave2.SetActive(false);
        }
        if (Nave == 3)
        {
            Nave3.SetActive(false);
        }
        if (Nave == 4)
        {
            Nave4.SetActive(false);
        }
        if (Nave == 5)
        {
            Nave5.SetActive(false);
        }
    }

    public void MuerteResetB()
    {
        StartCoroutine(ChangeSpeed(0, 1, 3));
        StartCoroutine(MuerteReset());
    }

    public IEnumerator MuerteReset()
    {
        yield return new WaitForSeconds(3);
        escenas.GameReset();
    }

    public void VolverGarajeB()
    {
        StartCoroutine(ChangeSpeed(0, 1, 3));
        StartCoroutine(VolverGaraje());
    }

    public IEnumerator VolverGaraje()
    {
        yield return new WaitForSeconds(3);
        escenas.PerderAGaraje();
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        glitch.enabled = true;
        yield return new WaitForSeconds(0.5f);
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
    }

    private void Update()
    {
        glitch.intensity = speed;
        vignette.chromaticAberration = speed2;
        blom.threshold = speed4;
    }
}