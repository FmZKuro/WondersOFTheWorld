using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;                    // Inst�ncia �nica da classe GameManager acess�vel de qualquer lugar

    public GameObject PlayerRef;                           // Refer�ncia para o objeto Player no jogo

    private void Awake()
    {
        if (instance != null && instance != this)          // Garante que h� apenas uma inst�ncia da classe GameManager em execu��o
        {
            Destroy(this);                                 // Destroi a inst�ncia atual se outra inst�ncia j� existe
        }
        else
        {
            instance = this;                               // Configura a inst�ncia como esta, se n�o h� nenhuma inst�ncia existente
            DontDestroyOnLoad(this.gameObject);            // Mant�m o GameManager durante as transi��es de cena
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
        PlayerRef = newPlayer;                              // Atribui um novo objeto Player � refer�ncia PlayerRef
    }

    public GameObject getPlayer()
    {
        return PlayerRef;                                  // Retorna o objeto Player armazenado em PlayerRef
    }
}
