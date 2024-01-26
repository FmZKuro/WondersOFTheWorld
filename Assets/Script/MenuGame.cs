using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGame : MonoBehaviour
{
    [SerializeField] private GameObject menuGame;       // Refer�ncia ao menu de pausa do jogo

    private bool esc;                                   // Vari�vel que indica se a tecla 'Esc' foi pressionada

    private void Start()
    {
        esc = false;                                    // Inicializa a vari�vel 'esc' como false no in�cio
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            esc = !esc;                                 // Inverte o valor de 'esc' diretamente

            if (esc)
            {
                Esc();                                  // Chama o m�todo para pausar o jogo
                //Cursor.visible = true;                  // Habilita o Cursor do Mouse no Menu
                //Cursor.lockState = CursorLockMode.None; // Destrava o Cursor
            }
            else
            {
                EscVoltar();                            // Chama o m�todo para despausar o jogo
            }
        }
    }

    public void Esc()                                   // M�todo para pausar o jogo e exibir o menu de pausa
    {
        menuGame.SetActive(true);                       // Ativa o menu de pausa
        Time.timeScale = 0f;                            // Pausa o tempo do jogo
    }

    public void EscVoltar()                             // M�todo para despausar o jogo e esconder o menu de pausa
    {
        Time.timeScale = 1f;                            // Retoma o tempo do jogo
        menuGame.SetActive(false);                      // Desativa o menu de pausa
        //Cursor.visible = false;                         // Desabilita o Cursor do Mouse in Game
        //Cursor.lockState = CursorLockMode.Locked;       // Travar o Cursor do Mouse no centro da tela
    }

    public void LoadMenuScene()                         // Carrega a cena do menu principal
    {
        SceneManager.LoadScene("Menu");                 // Carrega a cena "Menu"
    }

    public void Exit()                                  // Sai do aplicativo
    {
        Application.Quit();
        Debug.Log("sair");
    }


}
