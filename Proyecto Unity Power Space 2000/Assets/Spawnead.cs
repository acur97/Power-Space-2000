using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnead : MonoBehaviour {
    
    public static int Nivel = 1;

    private float VelocidadSpawn;
    private int count = 1;
    private int ran;

    private readonly string tag_EnemiCat1 = "EnemiCat1";
    private readonly string tag_EnemiCat2 = "EnemiCat2";
    private readonly string tag_Asteroides = "asteroides";

    private void Start()
    {
        if (Nivel == 1)
        {
            StartCoroutine(MalosLevel1(2, 0, 2, 50));
        }
    }

    public void VolverIniciarMalosLevel1()
    {
        StartCoroutine(VolverMalosLevel1());
    }

    IEnumerator VolverMalosLevel1()
    {
        StopCoroutine(MalosLevel1(2, 0, 2, 50));
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(MalosLevel1(2, 0, 2, 50));
    }

    IEnumerator MalosLevel1(float vel, int MinimoEnemigos, int MaximoEnemigos, int NumeroEnemigos)
    {
        count++;
        ran = Random.Range(MinimoEnemigos, (MaximoEnemigos + 1));
        if (ran == 0)
        {
            GameObject maloCat1 = ObjectPooler.SharedInstance.GetPooledObject(tag_EnemiCat1);
            if (maloCat1 != null)
            {
                maloCat1.transform.position = transform.position;
                maloCat1.SetActive(true);
            }
        }
        if (ran == 1)
        {
            GameObject asteroide = ObjectPooler.SharedInstance.GetPooledObject(tag_Asteroides);
            if (asteroide != null)
            {
                asteroide.transform.position = transform.position;
                asteroide.SetActive(true);
            }
        }
        if (ran == 2)
        {
            GameObject maloCat2 = ObjectPooler.SharedInstance.GetPooledObject(tag_EnemiCat2);
            if (maloCat2 != null)
            {
                maloCat2.transform.position = transform.position;
                maloCat2.SetActive(true);
            }
        }
        yield return new WaitForSeconds(vel);
        if (count <= NumeroEnemigos)
        {
            StartCoroutine(MalosLevel1(vel, MinimoEnemigos, MaximoEnemigos, NumeroEnemigos));
        }
    }
}
