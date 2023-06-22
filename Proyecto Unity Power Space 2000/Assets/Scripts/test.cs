using UnityEngine;

public class test : MonoBehaviour {

    public int Record;

    private void Awake(){
        //guarde un int llamado record
        PlayerPrefs.SetInt("Record", Record);
    }
}
