using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public void Queops()
    {
        SceneManager.LoadScene("queops");           // Carrega a cena "queops"
        Cursor.visible = false;                     // Desabilita o Cursor do Mouse in Game
        Cursor.lockState = CursorLockMode.Locked;   // Travar o Cursor do Mouse no centro da tela
    }

    public void Quefren()
    {
        SceneManager.LoadScene("quefren");          // Carrega a cena "quefren"
        Cursor.visible = false;                     // Desabilita o Cursor do Mouse in Game
        Cursor.lockState = CursorLockMode.Locked;   // Travar o Cursor do Mouse no centro da tela
    }

    public void Ruinas()
    {
        SceneManager.LoadScene("ruinas");           // Carrega a cena "ruinas"
        Cursor.visible = false;                     // Desabilita o Cursor do Mouse in Game
        Cursor.lockState = CursorLockMode.Locked;   // Travar o Cursor do Mouse no centro da tela
    }


}
