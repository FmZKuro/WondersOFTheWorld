using UnityEngine;

public class ColisaoComBoxUI : MonoBehaviour
{
    [SerializeField] public GameObject objetoReferencia;        // Atribua o objeto de referência no Unity Inspector

    private void Start()
    {
        if (objetoReferencia != null)                           // Desativa o objeto de referência no início, se estiver atribuído
        {
            objetoReferencia.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)             // Chamado quando um objeto entra no trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))                         // Verifica se o objeto que entrou é o Player
        {
            if (objetoReferencia != null)                       // Ativa o objeto de referência se estiver atribuído
            {
                objetoReferencia.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)              // Chamado quando um objeto sai do trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))                         // Verifica se o objeto que saiu é o Player
        {
            if (objetoReferencia != null)                       // Destroi o objeto de referência se estiver atribuído
            {
                Destroy(objetoReferencia);
            }
        }
    }
}
