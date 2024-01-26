using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] public string nomeDaCena ;     // Nome da cena a ser carregada (verifique se o nome está correto)

    public void CarregarCenaMenu()
    {        
        SceneManager.LoadScene("Menu");             // Carrega a cena chamada "Menu"
    }


    public void CarregarCenaFase()
    {        
        SceneManager.LoadScene(nomeDaCena);         // Carrega a cena chamada "Menu"
    }
}
