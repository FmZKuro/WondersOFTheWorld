using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenus : MonoBehaviour
{
    public void MenuLoad()
    {
        SceneManager.LoadScene("Menu");         // Carrega a cena do menu quando esta função é chamada
    }

}
