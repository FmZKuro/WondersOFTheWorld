using UnityEngine;

public class ColisaoComBoxUI : MonoBehaviour
{
    [SerializeField] public GameObject objetoReferencia;        // Atribua o objeto de refer�ncia no Unity Inspector

    private void Start()
    {
        if (objetoReferencia != null)                           // Desativa o objeto de refer�ncia no in�cio, se estiver atribu�do
        {
            objetoReferencia.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)             // Chamado quando um objeto entra no trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))                         // Verifica se o objeto que entrou � o Player
        {
            if (objetoReferencia != null)                       // Ativa o objeto de refer�ncia se estiver atribu�do
            {
                objetoReferencia.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)              // Chamado quando um objeto sai do trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))                         // Verifica se o objeto que saiu � o Player
        {
            if (objetoReferencia != null)                       // Destroi o objeto de refer�ncia se estiver atribu�do
            {
                Destroy(objetoReferencia);
            }
        }
    }
}
