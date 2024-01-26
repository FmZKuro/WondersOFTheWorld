using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuStart;
    [SerializeField] private GameObject menuConfg;
    [SerializeField] private GameObject menuPlay;
    [SerializeField] private GameObject menuCredito;
    [SerializeField] private GameObject menuChar;

    public void MenuStart()
    {
        menuStart.SetActive(true);

        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        menuChar.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("start");
    }

    public void MenuConfg()
    {
        menuConfg.SetActive(true);

        menuStart.SetActive(false);
        menuPlay.SetActive(false);
        menuChar.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("soun");
    }

    public void MenuPlay()
    {
        menuPlay.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuChar.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("play");
    }

    public void MenuChar()
    {
        menuChar.SetActive(true);

        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        menuCredito.SetActive(false);

        Debug.Log("");
    }

    public void MenuCredito()
    {
        menuCredito.SetActive(true);

        menuChar.SetActive(false);
        menuStart.SetActive(false);
        menuConfg.SetActive(false);
        menuPlay.SetActive(false);
        Debug.Log("credito");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("sair");
    }

    
}
