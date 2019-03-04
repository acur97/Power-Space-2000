using UnityEngine;

public class VelocidadEnemigos : MonoBehaviour {

    public Vector3 Velocidad;

    private void FixedUpdate()
    {
        transform.Translate(Velocidad);
    }
}
