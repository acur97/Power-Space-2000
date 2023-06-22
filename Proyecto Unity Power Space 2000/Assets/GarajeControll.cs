using System.Collections;
using UnityEngine;

public class GarajeControll : MonoBehaviour {

    public PublicScenes escenas;

    private readonly int nav1 = 1547491730;
    private readonly int nav2 = -986347480;
    private readonly int nav3 = -1305298754;
    private readonly int nav4 = 743845149;
    private readonly int nav5 = 1532042635;
    private readonly string trig_next = "next";
    private readonly string trig_back = "back";
    private readonly string trig_final = "final";

    private Animator anim;
    private string current;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManagerScript.Nave = 3;
    }

    public void SiguienteNave()
    {
        anim.SetTrigger(trig_next);
    }

    public void AtrasNave()
    {
        anim.SetTrigger(trig_back);
    }

    public void EscenaCargando()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == nav1)
        {
            GameManagerScript.Nave = 1;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == nav2)
        {
            GameManagerScript.Nave = 2;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == nav3)
        {
            GameManagerScript.Nave = 3;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == nav4)
        {
            GameManagerScript.Nave = 4;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == nav5)
        {
            GameManagerScript.Nave = 5;
        }
        StartCoroutine(cargar());
    }

    IEnumerator cargar()
    {
        anim.SetTrigger(trig_final);
        yield return new WaitForSeconds(1.8f);
        escenas.Cargando1();
    }
}
