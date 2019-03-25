using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour {

    public GameManagerScript manager;
    public Spawnead spawn;
    public GameObject PanelInfo;
    public Text PanelInfoText;

    private string gameID = "1603080";

    private readonly string str_NoSkip = "¡If you skip the videos, you will not get a reward!";
    private readonly string str_Error = "We could not load the ad, you can try again later";

    void Start()
	{
        Advertisement.Initialize(gameID);
    }

    public void ShowRewardedVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Time.timeScale = 0;
        Advertisement.Show("rewardedVideo", options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            Time.timeScale = 1;
            manager.yaMiroReward = true;
            spawn.VolverIniciarMalosLevel1();
            manager.RevivirPorAnuncio();
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");
            Time.timeScale = 1;
            manager.yaMiroReward = true;
            PanelInfo.SetActive(true);
            StartCoroutine(ApagarAlerta());
            PanelInfoText.text = str_NoSkip;
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
            Time.timeScale = 1;
            manager.yaMiroReward = false;
            PanelInfo.SetActive(true);
            StartCoroutine(ApagarAlerta());
            PanelInfoText.text = str_Error;
        }
    }

    IEnumerator ApagarAlerta()
    {
        yield return new WaitForSeconds(2);
        PanelInfo.SetActive(false);
    }
}
