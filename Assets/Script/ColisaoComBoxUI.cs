using UnityEngine;

public class ColisaoComBoxUI : MonoBehaviour
{
    [SerializeField] public GameObject objetoReferencia; // Atribua o objeto de referência no Unity Inspector

    private void Start()
    {
        if (objetoReferencia != null)
        {
            objetoReferencia.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objetoReferencia != null)
            {
                objetoReferencia.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objetoReferencia != null)
            {
                Destroy(objetoReferencia);
            }
        }
    }
}
