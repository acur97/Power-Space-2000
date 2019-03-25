using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission_HeartRate : MonoBehaviour {

    static readonly int material_Color = Shader.PropertyToID("_EmissionColor");

    public Material MaterialPiso;
    public Color ColorHDR;
    public float MinimoHDR;
    public float MaximoHDR;
    public float TiempoBeat;
    public float esperaNegro;

    private float speed;

    private void Awake()
    {
        StartCoroutine(ChangeSpeedUp(MinimoHDR, MaximoHDR, TiempoBeat));
        MaterialPiso.SetColor(material_Color, ColorHDR * MinimoHDR);
    }

    private void OnApplicationQuit()
    {
        MaterialPiso.SetColor(material_Color, ColorHDR * MaximoHDR);
    }

    IEnumerator ChangeSpeedUp(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
        StartCoroutine(ChangeSpeedDown(MaximoHDR, MinimoHDR, TiempoBeat));
    }

    IEnumerator ChangeSpeedDown(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
        yield return new WaitForSeconds(esperaNegro);
        StartCoroutine(ChangeSpeedUp(MinimoHDR, MaximoHDR, TiempoBeat));
    }

    private void Update()
    {
        MaterialPiso.SetColor(material_Color, ColorHDR * speed);
    }
}
