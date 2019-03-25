using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

    public GameObject bala1;
    public GameObject bala2;
    public GameObject bala3;
    public MeshRenderer mundo;

    private bool disparo = false;
    
    void Update ()
    {
        if (mundo.isVisible && bala1.activeSelf == false)
        {
            StartCoroutine(TresDisparos());
            disparo = true;
        }
    }

    IEnumerator TresDisparos()
    {
        yield return new WaitForSeconds(0.2f);
        bala1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bala2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bala3.SetActive(true);
    }
}
