using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInicial1 : MonoBehaviour {

    public float DuracionFade;
    public Color32 col;

    public Image img;
    private float speed;

    private void Awake()
    {
        img = GetComponent<Image>();
        speed = 255;
    }

    private void Start()
    {
        StartCoroutine(ChangeSpeed(255, 0, DuracionFade));
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        new Color32(col.r, col.g, col.b, 255);
        yield return new WaitForSeconds(0.5f);
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void Update()
    {
        img.color = new Color32(col.r, col.g, col.b, (byte)speed);
    }
}
