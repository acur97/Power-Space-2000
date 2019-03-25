using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicaOST : MonoBehaviour {

    private Canvas canv;
    private Camera cam;
    private AudioSource source;
    private Animator anim;
    private int NumeroCancion;
    private int len;

    static readonly int anim_abrir = Animator.StringToHash("abrir");
    static readonly string text_puntoespacio = ". ";
    private readonly string pref_vol = "Volumen";

    [Header("volumen")]
    public AudioSource master;
    public static AudioSource Smaster;

    [Header("Canciones")]
    public AudioClip[] Canciones;

    [Space]
    [Header("Panel de mas informacion")]
    public GameObject PanelInfo;

    [Space]
    [Header("Panel info musica")]
    public GameObject PanelinfoMusica;
    [Header("Panel info artista y nombre")]
    public Text text_artista;
    public Text text_cancion;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(pref_vol))
        {
            PlayerPrefs.SetFloat(pref_vol, 1);
        }

        PanelInfo.SetActive(false);

        canv = GetComponent<Canvas>();
        source = GetComponent<AudioSource>();
        anim = PanelinfoMusica.GetComponent<Animator>();

        len = Canciones.Length;
    }

    private void Start()
    {
        master.volume = PlayerPrefs.GetFloat(pref_vol);
        playRandomMusic();
    }

    private void OnLevelWasLoaded(int level)
    {
        Smaster = master;
        cam = FindObjectOfType<Camera>();

        canv.worldCamera = cam;
        canv.planeDistance = 0.5f;
    }

    void Update ()
    {
        if(!source.isPlaying)
        {
            playRandomMusic();
        }
	}

    public void playRandomMusic()
    {
        //NumeroCancion = Random.Range(0, len);
        int rando = Random.Range(0, len);
        while(rando == NumeroCancion)
        {
            rando = Random.Range(0, len);
        }
        while(rando != NumeroCancion)
        {
            NumeroCancion = Random.Range(0, len);
        }
        source.clip = Canciones[NumeroCancion];
        source.Play();
        StartCoroutine(DelayPanelMusica());
    }

    public void AbrirDelayPanelMusica()
    {
        StartCoroutine(DelayPanelMusica());
    }

    IEnumerator DelayPanelMusica()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger(anim_abrir);
        //text_artista.text =
        text_cancion.text = (NumeroCancion + 1) + text_puntoespacio + Canciones[NumeroCancion].name;
    }

    public void MasInformacion()
    {
        PanelInfo.SetActive(true);
    }

    public void SalirMasInfo()
    {
        PanelInfo.SetActive(false);
    }
}
