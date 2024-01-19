using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGame : MonoBehaviour
{
    [SerializeField] private GameObject menuGame;

    private bool esc ;

    private void Start()
    {
        esc = false;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Inverta o valor de 'esc' diretamente
            esc = !esc;

            if (esc)
            {
                Esc();
            }
            else
            {
                EscVoltar();
            }
        }
    }


    public void Esc()
    {

        menuGame.SetActive(true);
        Time.timeScale = 0f;

    }

    public void EscVoltar()
    {
        Time.timeScale = 1f;
        menuGame.SetActive(false);

    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("sair");
    }


}
