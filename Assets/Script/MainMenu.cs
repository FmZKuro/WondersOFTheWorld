using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuStart;          // Refer�ncia ao menu de in�cio
    [SerializeField] private GameObject menuConfg;          // Refer�ncia ao menu de configura��es
    [SerializeField] private GameObject menuPlay;           // Refer�ncia ao menu de jogo
    [SerializeField] private GameObject menuChar;           // Refer�ncia ao menu de sele��o de personagem

    public void MenuStart()                                 // Ativa o menu de in�cio e desativa os outros menus
    {
        menuStart.SetActive(true);

        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        menuChar.SetActive(false);
        Debug.Log("start");
    }

    public void MenuConfg()                                 // Ativa o menu de configura��es e desativa os outros menus
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

    public void MenuChar()                                  // Ativa o menu de sele��o de personagem e desativa os outros menus
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
