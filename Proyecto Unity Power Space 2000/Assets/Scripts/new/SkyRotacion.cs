using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotacion : MonoBehaviour {

    static readonly int Shader_rotacion = Shader.PropertyToID("_Rotation");

    public float VelocidadRotacion = 3;
    [Header("45° = 15")]
    public float RotacionInicial = 15;

    void Update() {
        RotacionInicial += 0.01f;
        RenderSettings.skybox.SetFloat(Shader_rotacion, RotacionInicial * VelocidadRotacion);
	}
}
