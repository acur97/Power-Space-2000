using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Disparando : MonoBehaviour {

    public GameObject BotonDisparo;
    public Transform PuntoMira;
    public Quaternion zero = new Quaternion(0, 0, 90, 0);
    //public List<GameObject> createdInstances = new List<GameObject>();
    public Image imgBoton;
    public Transform PuntoDisparo1;
    public Transform PuntoDisparo2;
    private bool undido;
    private EventTrigger ButBoton;

    private void OnEnable()
    {
        imgBoton = BotonDisparo.GetComponent<Image>();
        ButBoton = BotonDisparo.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => { Unde1(); });
        ButBoton.triggers.Add(entry);


        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventData) => { Suelte1(); });
        ButBoton.triggers.Add(entry2);
    }

    public void Unde1()
    {
        undido = true;
        StartCoroutine(Dispara());
        imgBoton.color = new Color(1, 1, 1, 0.75f);
    }

    public void Suelte1()
    {
        undido = false;
        imgBoton.color = new Color(1, 1, 1, 1);
    }

    IEnumerator Dispara()
    {
        Boton(PuntoDisparo1);
        Boton(PuntoDisparo2);
        yield return new WaitForSeconds(0.5f);
        if (undido == true)
        {
            StartCoroutine(Dispara());
        }
    }

    public void Boton(Transform punto)
    {
        /*GameObject currentInstance = IcosphereObjectPool.current.GetInstanceFromPool(punto.position, zero);
        createdInstances.Add(currentInstance);
        currentInstance.SetActive(true);
        currentInstance.transform.LookAt(PuntoMira);*/
    }
}
