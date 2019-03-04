using UnityEngine;

public class VelocidadJugador : MonoBehaviour {

    private Rigidbody rigi;
    public Vector3 velocidad;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigi.velocity = velocidad;
    }
}
