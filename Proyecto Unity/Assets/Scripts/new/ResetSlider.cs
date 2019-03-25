using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSlider : MonoBehaviour {

    private Slider sli;
    private float mitad = 0.5f;
    private float speed;
    private bool devolviendo;

    private void Awake()
    {
        sli = GetComponent<Slider>();
    }

    public void Undiendo()
    {
        devolviendo = false;
        StopAllCoroutines();
    }

    public void Suelte()
    {
        devolviendo = true;
        StartCoroutine(ChangeSpeed(sli.value, mitad, 0.4f));
	}

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed = v_end;
    }

    private void Update()
    {
        if(devolviendo)
            sli.value = speed;
    }
}