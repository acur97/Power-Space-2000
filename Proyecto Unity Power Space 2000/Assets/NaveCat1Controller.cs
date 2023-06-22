using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NaveCat1Controller : MonoBehaviour {

    public Transform PuntoMira1;
    public Transform PuntoMira2;
    public Transform PuntoDisparo1;
    public Transform PuntoDisparo2;
    public GameObject BotonDisparo;

    private Image imgBoton;
    private EventTrigger butBoton;
    private bool undido;

    private readonly Quaternion quat = new Quaternion(0, 0, 90, 0);
    private readonly Color color_undido = new Color(1, 1, 1, 0.75f);
    private readonly Color color_suelta = new Color(1, 1, 1, 1);
    private readonly string tag_bala = "Bala";

    private void Start()
    {
        imgBoton = BotonDisparo.GetComponent<Image>();
        butBoton = BotonDisparo.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) => { Unde(); });
        butBoton.triggers.Add(entry);


        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((eventData) => { Suelte(); });
        butBoton.triggers.Add(entry2);
    }

    public void Unde()
    {
        undido = true;
        StartCoroutine(Dispara());
        imgBoton.color = color_undido;
    }

    public void Suelte()
    {
        undido = false;
        imgBoton.color = color_suelta;
    }

    IEnumerator Dispara()
    {
        Disparar();
        yield return new WaitForSeconds(0.5f);
        if (undido == true)
        {
            StartCoroutine(Dispara());
        }
    }

    public void Disparar()
    {
        GameObject bullet1 = ObjectPooler.SharedInstance.GetPooledObject(tag_bala);
        if (bullet1 != null)
        {
            bullet1.transform.position = PuntoDisparo1.position;
            bullet1.transform.rotation = quat;
            bullet1.SetActive(true);
            bullet1.transform.LookAt(PuntoMira1);
        }
        GameObject bullet2 = ObjectPooler.SharedInstance.GetPooledObject(tag_bala);
        if (bullet2 != null)
        {
            bullet2.transform.position = PuntoDisparo2.position;
            bullet2.transform.rotation = quat;
            bullet2.SetActive(true);
            bullet2.transform.LookAt(PuntoMira2);
        }
    }
}
