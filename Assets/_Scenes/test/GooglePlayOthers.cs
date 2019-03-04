using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayOthers : MonoBehaviour {

    public Text choose;

    private string UserName;

    private readonly string Pref_NameUsuario = "NameUsuario";
    private readonly string Pref_Progress_DestroyFirstEenemy = "Progress_DestroyFirstEenemy";
    private readonly string str_choose = "Choose your ship ";

    private void Awake()
    {
        UserName = PlayerPrefs.GetString(Pref_NameUsuario);
        choose.text = str_choose + UserName;
    }

    public void LogOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
    
    public void verLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void verArchivements()
    {
        Social.ShowAchievementsUI();
    }

    public void DesbloquearWelcome()
    {
        Social.ReportProgress(GPGSIds.achievement_welcome, 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void DesbloquearDescubrirCreadorMusica()
    {
        Social.ReportProgress(GPGSIds.achievement_discover_the_creator_of_the_games_soundtrack, 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void DesbloquearCompletarTutorial()
    {
        Social.ReportProgress(GPGSIds.achievement_complete_the_tutorial, 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void DesbloquearMasPaguer()
    {
        Social.ReportProgress(GPGSIds.achievement_unlock_more_power, 100.0f, (bool success) => {
            // handle success or failure
        });
    }

    public void PostearScoreBestAnyLevel(long Score)
    {
        Social.ReportScore(Score, GPGSIds.leaderboard_best_score_on_any_level, (bool success) => {
            // handle success or failure
        });
    }
}