using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAlbum : MonoBehaviour {

    static readonly string linkD = "https://mitchmurder.bandcamp.com/album/television-ep";


    public void LinkDescargaAlbum()
    {
        Application.OpenURL(linkD);
    }
}
