using System.Collections;
using UnityEngine;

public class EnemiCat2Controller : MonoBehaviour {

    public Transform PuntoDisparo;
    public float VelocidadDisparo;

    private Transform PuntoNave;

    private readonly Quaternion quat = new Quaternion(0, 0, 90, 0);
    private readonly string tag_balaBola2 = "BalaBola2";
    private readonly string tag_punto = "PuntoNave";

    private void Awake()
    {
        transform.transform.localPosition = new Vector3(Random.Range(-9, 10), Random.Range(-6, 5.5f), 0);
        PuntoNave = GameObject.FindGameObjectWithTag(tag_punto).transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "naves")
        {
            StartCoroutine(Dispara());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "naves")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Dispara()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(tag_balaBola2);
        if (bullet != null)
        {
            bullet.transform.position = PuntoDisparo.position;
            bullet.transform.rotation = quat;
            bullet.SetActive(true);
            bullet.transform.LookAt(PuntoNave);
        }
        yield return new WaitForSeconds(VelocidadDisparo);
        StartCoroutine(Dispara());
    }
}
