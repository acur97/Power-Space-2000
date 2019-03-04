using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mundos : MonoBehaviour {

    public GameManagerScript GameManager;
    public GameObject[] CosasParaDesactivar;

    void Update ()
    {
		if(gameObject.transform.localScale.x < 0.2)
        {
            GameManager.AumentarPuntos(50);
            Destroy(gameObject);
            for (int i = 0; i < CosasParaDesactivar.Length; i++)
            {
                CosasParaDesactivar[i].SetActive(false);
            }
        }
	}
}
