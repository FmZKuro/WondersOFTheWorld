using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;                    // Instância única da classe GameManager acessível de qualquer lugar

    public GameObject PlayerRef;                           // Referência para o objeto Player no jogo

    private void Awake()
    {
        if (instance != null && instance != this)          // Garante que há apenas uma instância da classe GameManager em execução
        {
            Destroy(this);                                 // Destroi a instância atual se outra instância já existe
        }
        else
        {
            instance = this;                               // Configura a instância como esta, se não há nenhuma instância existente
            DontDestroyOnLoad(this.gameObject);            // Mantém o GameManager durante as transições de cena
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayer(GameObject newPlayer)
    {
        PlayerRef = newPlayer;                              // Atribui um novo objeto Player à referência PlayerRef
    }

    public GameObject getPlayer()
    {
        return PlayerRef;                                  // Retorna o objeto Player armazenado em PlayerRef
    }
}
