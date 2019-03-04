using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class MoverNave : MonoBehaviour {

    public Vector2 speed;
    public Transform CanvasMira;

    public static float MultiplicadorMoverNave = 1;

    private float Hmove;
    private float Vmove;
    private Transform trans;

    private float NaveX;
    private float NaveY;

    private void Awake()
    {
        trans = transform;
    }

    void Update()
    {
        Hmove = CnInputManager.GetAxis("Horizontal") * Time.deltaTime * speed.x * MultiplicadorMoverNave;
        Vmove = CnInputManager.GetAxis("Vertical") * Time.deltaTime * speed.y * MultiplicadorMoverNave;

        trans.Translate(Hmove, Vmove, 0);

        NaveX = trans.localPosition.x;
        NaveY = trans.localPosition.y;

        trans.localPosition = new Vector3(Mathf.Clamp(NaveX, -6.5f, 6.5f), Mathf.Clamp(NaveY, -5, 3), 10);

        //CanvasMira.localPosition = new Vector3(NaveX * 8, NaveY + 50, 500);
        CanvasMira.localPosition = new Vector3(NaveX, NaveY + 6.25f, 62.5f);

        trans.localEulerAngles = new Vector3(-NaveY * 4, NaveX * 4);
    }
}