using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuStart;          // Referência ao menu de início
    [SerializeField] private GameObject menuConfg;          // Referência ao menu de configurações
    [SerializeField] private GameObject menuPlay;           // Referência ao menu de jogo
    [SerializeField] private GameObject menuChar;           // Referência ao menu de seleção de personagem

    public void MenuStart()                                 // Ativa o menu de início e desativa os outros menus
    {
        menuStart.SetActive(true);

        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        menuChar.SetActive(false);
        Debug.Log("start");
    }

    public void MenuConfg()                                 // Ativa o menu de configurações e desativa os outros menus
    {
        menuConfg.SetActive(true);

        menuStart.SetActive(false);
        menuPlay.SetActive(false);
        menuChar.SetActive(false);
        Debug.Log("");
    }

    public void MenuPlay()                                  // Ativa o menu de jogo e desativa os outros menus
    {
        menuPlay.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuChar.SetActive(false);
        Debug.Log("");
    }

    public void MenuChar()                                  // Ativa o menu de seleção de personagem e desativa os outros menus
    {
        menuChar.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        Debug.Log("");
    }          

    public void Exit()                                      // Sair do Game
    {
        Application.Quit();
        Debug.Log("sair");
    }    
}
