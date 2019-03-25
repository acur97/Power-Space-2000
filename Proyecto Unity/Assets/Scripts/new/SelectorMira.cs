using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorMira : MonoBehaviour {

    public static int cual = 10;

    public Sprite mira1;
    public Sprite mira2;
    public Sprite mira3;
    public Sprite mira4;
    public Sprite mira5;
    public Sprite mira6;
    public Sprite mira7;
    public Sprite mira8;
    public Sprite mira9;
    public Sprite mira10;
    public Sprite mira11;
    public Sprite mira12;
    public Sprite mira13;
    public Sprite mira14;
    [Space]
    public Image Mira;

    private void Awake()
    {
        if(cual == 1)
        {
            Mira.sprite = mira1;
        }
        if(cual == 2)
        {
            Mira.sprite = mira2;
        }
        if (cual == 3)
        {
            Mira.sprite = mira3;
        }
        if (cual == 4)
        {
            Mira.sprite = mira4;
        }
        if (cual == 5)
        {
            Mira.sprite = mira5;
        }
        if (cual == 6)
        {
            Mira.sprite = mira6;
        }
        if (cual == 7)
        {
            Mira.sprite = mira7;
        }
        if (cual == 8)
        {
            Mira.sprite = mira8;
        }
        if (cual == 9)
        {
            Mira.sprite = mira9;
        }
        if (cual == 10)
        {
            Mira.sprite = mira10;
        }
        if (cual == 11)
        {
            Mira.sprite = mira11;
        }
        if (cual == 12)
        {
            Mira.sprite = mira12;
        }
        if (cual == 13)
        {
            Mira.sprite = mira13;
        }
        if (cual == 14)
        {
            Mira.sprite = mira14;
        }
    }

    public void CambioMira(int cualMira)
    {
        if (cualMira == 1)
        {
            Mira.sprite = mira1;
        }
        if (cualMira == 2)
        {
            Mira.sprite = mira2;
        }
        if (cualMira == 3)
        {
            Mira.sprite = mira3;
        }
        if (cualMira == 4)
        {
            Mira.sprite = mira4;
        }
        if (cualMira == 5)
        {
            Mira.sprite = mira5;
        }
        if (cualMira == 6)
        {
            Mira.sprite = mira6;
        }
        if (cualMira == 7)
        {
            Mira.sprite = mira7;
        }
        if (cualMira == 8)
        {
            Mira.sprite = mira8;
        }
        if (cualMira == 9)
        {
            Mira.sprite = mira9;
        }
        if (cualMira == 10)
        {
            Mira.sprite = mira10;
        }
        if (cualMira == 11)
        {
            Mira.sprite = mira11;
        }
        if (cualMira == 12)
        {
            Mira.sprite = mira12;
        }
        if (cualMira == 13)
        {
            Mira.sprite = mira13;
        }
        if (cualMira == 14)
        {
            Mira.sprite = mira14;
        }
    }
}