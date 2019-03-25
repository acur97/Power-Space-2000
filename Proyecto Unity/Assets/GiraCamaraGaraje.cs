using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraCamaraGaraje : MonoBehaviour {

    private Animator anim;

    private readonly string trig_next = "next";
    private readonly string trig_back = "back";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void NextGiro()
    {
        anim.SetTrigger(trig_next);
    }

    public void BackGiro()
    {
        anim.SetTrigger(trig_back);
    }
}
