using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAsteroides : MonoBehaviour {

    public Transform PuntoGiro;
    [Range(0, 1)]
    public float angle;
    public List<GameObject> ateroides;

    private GameObject[] objetos;
    private Vector3 vector;

    private void Awake()
    {
        foreach (Transform obj in transform)
        {
            ateroides.Add(obj.gameObject);
        }
        objetos = ateroides.ToArray();
        vector = new Vector3(Random.Range(0, angle), Random.Range(0, angle), Random.Range(0, angle));
    }

    private void Update()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].transform.RotateAround(PuntoGiro.position, vector, angle);
            objetos[i].transform.Rotate(0, angle*4, 0);
        }
    }
}
