using System.Collections;
using UnityEngine;

public class Disparando2 : MonoBehaviour {

    public Transform PuntoDisparo;
    public GameObject LaserPrefab;
    public Transform PuntoNave;

    private readonly Quaternion quat = new Quaternion(0, 0, 90, 0);

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "naves")
        {
            StartCoroutine(Dispara());
        }
        else
        {
            StopCoroutine(Dispara());
        }
    }

    IEnumerator Dispara()
    {
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(2);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
        yield return new WaitForSeconds(0.5f);
        Instantiate(LaserPrefab, PuntoDisparo.position, quat, PuntoDisparo).transform.LookAt(PuntoNave);
    }
}