using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayStart : MonoBehaviour {

    public Text logText;
    public GameObject CanvasReLogin;
    public Button Bstart;
    [Space]
    public GameObject InitialFade;

    private string UserName;

    private readonly string Pref_NameUsuario = "NameUsuario";
    private readonly string Pref_SampleUser = "Commander";
    private readonly string str_welcome = "Welcome ";
    private readonly string str_load = "Loading";
    private readonly string str_login = "Loggin in...";
    private readonly string str_relogin = "Re-Signing in...";
    private readonly string str_norelogin = "You can authenticate later";
    private readonly string str_wait = "...";

    private void Awake()
    {
        InitialFade.SetActive(true);
        logText.text = str_load;
    }

    void Start ()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
        Login();
	}
	
	public void Login()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                ((PlayGamesPlatform)Social.Active).SetGravityForPopups(GooglePlayGames.BasicApi.Gravity.BOTTOM);
            }
        });
        logText.text = str_login;
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                UserName = Social.localUser.userName;
                logText.text = str_welcome + UserName;
                PlayerPrefs.SetString(Pref_NameUsuario, UserName);
            }
            else
            {
                CanvasReLogin.SetActive(true);
                Bstart.interactable = false;
                logText.text = str_wait;
            }
        });
    }

    public void NoReLogin()
    {
        CanvasReLogin.SetActive(false);
        logText.text = str_norelogin;
        Bstart.interactable = true;
        UserName = Pref_SampleUser;
        PlayerPrefs.SetString(Pref_NameUsuario, UserName);
    }

    public void ReLogin()
    {
        CanvasReLogin.SetActive(false);
        Bstart.interactable = true;
        logText.text = str_relogin;
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                UserName = Social.localUser.userName;
                logText.text = str_welcome + UserName;
                PlayerPrefs.SetString(Pref_NameUsuario, UserName);
            }
            else
            {
                CanvasReLogin.SetActive(true);
                logText.text = str_wait;
                Bstart.interactable = false;
            }
        });
    }
}
