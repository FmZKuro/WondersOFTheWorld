using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxCollision : MonoBehaviour
{
    public string tagCollider;                                  // Tag associada aos objetos que causar�o a intera��o ao entrar no trigger

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)             // Chamado quando um objeto entra no trigger associado a este Collider2D
    {
        if (other.gameObject.tag == tagCollider)                // Verifica se o objeto que entrou tem a tag esperada
        {
            if (other.GetComponent<Health>() != null)           // Verifica se o objeto tem um componente de sa�de
            {
                other.GetComponent<Health>().takeDamage();      // Chama a fun��o para causar dano ao objeto
            }
            else
            {
                Destroy(other.gameObject);                      // Destroi o objeto se n�o tiver um componente de sa�de
            }
        }         
    }
}
