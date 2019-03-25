using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour {

    public Text RecordUI;

    private void Awake()
    {
        //extraigo el valor guardado en record y lo veo en un Texts
        RecordUI.text = PlayerPrefs.GetInt("Record").ToString();
    }
}
