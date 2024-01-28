using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
                                                            // Telas de referencia para manipulação
    [SerializeField] private GameObject menuStart;
    [SerializeField] private GameObject menuConfg;
    [SerializeField] private GameObject menuPlay;
    [SerializeField] private GameObject menuCredito;

    
    public void MenuStart()                                 // metodo paracaregar menu inicial
    { 
        menuStart.SetActive(true);

        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("start");
    }

    public void MenuConfg()                                 // metodo paracaregar as configuraçoes
    {
        menuConfg.SetActive(true);

        menuStart.SetActive(false);
        menuPlay.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("confg");
    }

    public void MenuPlay()                                  // metodo paracaregar tela de seleção de fases
    {
        menuPlay.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("play");
    }
      

    public void MenuCredito()                               // metodo paracaregar tela de creditos
    {
        menuCredito.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuPlay.SetActive(false);

        Debug.Log("credito");
    }

    public void Tutorial()                                  //logar fase tutorial
    {
        SceneManager.LoadScene("Ruinas");
        Debug.Log("load tutorial");
    }

    public void Exit()                                      // saida do jogo
    {
        Application.Quit();
        Debug.Log("sair");
    }    
}
