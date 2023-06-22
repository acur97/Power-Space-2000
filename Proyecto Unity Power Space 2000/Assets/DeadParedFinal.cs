using UnityEngine;

public class DeadParedFinal : MonoBehaviour {

    [Header("Destruir o desactivar")]
    public bool Desactivar = true;

    private readonly string tag_finis = "Finish";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag_finis)
        {
            if (Desactivar)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }
}
