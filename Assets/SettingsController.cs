using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    [Header("audio")]
    public Slider AudioSlider;
    private readonly string pref_vol = "Volumen";

    [Header("sensibilidad")]
    public Slider SensiSlider;
    public Text SensiText;
    private readonly string tex_titulo1 = "Flight sensitivity: ";
    private readonly string tex_titulo2 = "%";
    private readonly string pref_sensi = "SensibilidadF";

    [Header("graficos")]
    public Toggle GraficosAdaptativos;
    public Slider GraficosSlider;
    private float reso;
    private readonly string pref_graf_f = "GraficosFloat";
    private readonly string pref_graf_b = "Adaptativo";

    [Header("Cambio miras")]
    public GameObject mira1;
    public GameObject mira2;
    public GameObject mira3;
    public GameObject mira4;
    public GameObject mira5;
    public GameObject mira6;
    public GameObject mira7;
    public GameObject mira8;
    public GameObject mira9;
    public GameObject mira10;
    public GameObject mira11;
    public GameObject mira12;
    public GameObject mira13;
    public GameObject mira14;
    private Button Bmira1;
    private Button Bmira2;
    private Button Bmira3;
    private Button Bmira4;
    private Button Bmira5;
    private Button Bmira6;
    private Button Bmira7;
    private Button Bmira8;
    private Button Bmira9;
    private Button Bmira10;
    private Button Bmira11;
    private Button Bmira12;
    private Button Bmira13;
    private Button Bmira14;
    private Outline Omira1;
    private Outline Omira2;
    private Outline Omira3;
    private Outline Omira4;
    private Outline Omira5;
    private Outline Omira6;
    private Outline Omira7;
    private Outline Omira8;
    private Outline Omira9;
    private Outline Omira10;
    private Outline Omira11;
    private Outline Omira12;
    private Outline Omira13;
    private Outline Omira14;
    private readonly string pref_Mira = "CulMira";

    private MusicaOST music;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("OST").GetComponent<MusicaOST>();

        if (!PlayerPrefs.HasKey(pref_Mira))
        {
            PlayerPrefs.SetInt(pref_Mira, 10);
            SelectorMira.cual = PlayerPrefs.GetInt(pref_Mira);
        }
        else
        {
            SelectorMira.cual = PlayerPrefs.GetInt(pref_Mira);
        }

        Bmira1 = mira1.GetComponent<Button>();
        Bmira2 = mira2.GetComponent<Button>();
        Bmira3 = mira3.GetComponent<Button>();
        Bmira4 = mira4.GetComponent<Button>();
        Bmira5 = mira5.GetComponent<Button>();
        Bmira6 = mira6.GetComponent<Button>();
        Bmira7 = mira7.GetComponent<Button>();
        Bmira8 = mira8.GetComponent<Button>();
        Bmira9 = mira9.GetComponent<Button>();
        Bmira10 = mira10.GetComponent<Button>();
        Bmira11 = mira11.GetComponent<Button>();
        Bmira12 = mira12.GetComponent<Button>();
        Bmira13 = mira13.GetComponent<Button>();
        Bmira14 = mira14.GetComponent<Button>();

        Omira1 = mira1.GetComponent<Outline>();
        Omira2 = mira2.GetComponent<Outline>();
        Omira3 = mira3.GetComponent<Outline>();
        Omira4 = mira4.GetComponent<Outline>();
        Omira5 = mira5.GetComponent<Outline>();
        Omira6 = mira6.GetComponent<Outline>();
        Omira7 = mira7.GetComponent<Outline>();
        Omira8 = mira8.GetComponent<Outline>();
        Omira9 = mira9.GetComponent<Outline>();
        Omira10 = mira10.GetComponent<Outline>();
        Omira11 = mira11.GetComponent<Outline>();
        Omira12 = mira12.GetComponent<Outline>();
        Omira13 = mira13.GetComponent<Outline>();
        Omira14 = mira14.GetComponent<Outline>();
    }

    private void Start()
    {
        AudioSlider.value = PlayerPrefs.GetFloat(pref_vol);

        if (PlayerPrefs.HasKey(pref_sensi))
        {
            float sens = PlayerPrefs.GetFloat(pref_sensi);
            SensiSlider.value = sens;
            SensiText.text = tex_titulo1 + sens + tex_titulo2;
            MoverNave.MultiplicadorMoverNave = sens;
        }

        if (PlayerPrefs.HasKey(pref_graf_f))
        {
            if (PlayerPrefs.GetInt(pref_graf_b) == 1)
            {
                GraficosAdaptativos.isOn = true;
                GraficosSlider.enabled = false;
                GraficosSlider.value = 0.667f;
                GraficosSlider.value = 0.667f;
            }
            else
            {
                GraficosAdaptativos.isOn = false;
                GraficosSlider.enabled = true;
                float res = PlayerPrefs.GetFloat(pref_graf_f);
                GraficosSlider.value = res;
                GraficosSlider.value = res;
            }
        }

        if (PlayerPrefs.GetInt(pref_graf_b) == 1 || !PlayerPrefs.HasKey(pref_graf_b))
        {
            GraficosAdaptativos.isOn = true;
            GraficosSlider.enabled = false;
        }
        else
        {
            GraficosAdaptativos.isOn = false;
            GraficosSlider.enabled = true;
            GraficosSlider.value = 0.667f;
            GraficosSlider.value = PlayerPrefs.GetFloat(pref_graf_f);
        }
    }

    public void ResetGame()
    {
        Destroy(music);
        PlayerPrefs.DeleteAll();
        Initiate.Fade("MenuPlay", Color.black, 1);
    }

    public void AbrirPanelStaticMusica()
    {
        music.AbrirDelayPanelMusica();
    }

    public void CambiarVolumen(float vol)
    {
        PlayerPrefs.SetFloat(pref_vol, vol);
        MusicaOST.Smaster.volume = vol;
    }

    public void CambiarSensibilidad(float sensi)
    {
        PlayerPrefs.SetFloat(pref_sensi, sensi);
        SensiText.text = tex_titulo1 + sensi + tex_titulo2;
        MoverNave.MultiplicadorMoverNave = sensi;
    }

    public void ResetSensiSlider()
    {
        PlayerPrefs.SetFloat(pref_sensi, 1);
        SensiSlider.value = 1;
        SensiText.text = tex_titulo1 + 1 + tex_titulo2;
        MoverNave.MultiplicadorMoverNave = 1;
    }

    public void CambiarResolucion(float res)
    {
        reso = res;
        PlayerPrefs.SetFloat(pref_graf_f, res);
    }

    public void ActivaNewRes()
    {
        PlayerPrefs.SetFloat(pref_graf_f, reso);
        Resolucion.NewResMaster(reso);
    }

    public void ToggleAdaptativo(bool adap)
    {
        if (adap)
        {
            GraficosSlider.enabled = false;
            PlayerPrefs.SetInt(pref_graf_b, 1);
            PlayerPrefs.SetFloat(pref_graf_f, 0.667f);
            Resolucion.NewResMaster(0.667f);
        }
        else
        {
            GraficosSlider.value = 0.667f;
            GraficosSlider.enabled = true;
            PlayerPrefs.SetInt(pref_graf_b, 0);
            PlayerPrefs.SetFloat(pref_graf_f, 0.667f);
            Resolucion.NewResMaster(0.667f);
        }
    }

    public void ActivarCanvasMira()
    {
        if (SelectorMira.cual == 1)
        {
            Bmira1.interactable = false;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = true;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 2)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = false;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = true;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 3)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = false;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = true;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 4)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = false;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = true;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 5)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = false;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = true;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 6)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = false;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = true;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 7)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = false;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = true;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 8)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = false;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = true;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 9)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = false;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = true;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 10)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = false;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = true;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 11)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = false;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = true;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 12)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = false;
            Bmira13.interactable = true;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = true;
            Omira13.enabled = false;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 13)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = false;
            Bmira14.interactable = true;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = true;
            Omira14.enabled = false;
        }
        if (SelectorMira.cual == 14)
        {
            Bmira1.interactable = true;
            Bmira2.interactable = true;
            Bmira3.interactable = true;
            Bmira4.interactable = true;
            Bmira5.interactable = true;
            Bmira6.interactable = true;
            Bmira7.interactable = true;
            Bmira8.interactable = true;
            Bmira9.interactable = true;
            Bmira10.interactable = true;
            Bmira11.interactable = true;
            Bmira12.interactable = true;
            Bmira13.interactable = true;
            Bmira14.interactable = false;

            Omira1.enabled = false;
            Omira2.enabled = false;
            Omira3.enabled = false;
            Omira4.enabled = false;
            Omira5.enabled = false;
            Omira6.enabled = false;
            Omira7.enabled = false;
            Omira8.enabled = false;
            Omira9.enabled = false;
            Omira10.enabled = false;
            Omira11.enabled = false;
            Omira12.enabled = false;
            Omira13.enabled = false;
            Omira14.enabled = true;
        }
    }

    public void CambiarMira(int Boton)
    {
        SelectorMira.cual = Boton;
        PlayerPrefs.SetInt(pref_Mira, Boton);
    }
}
