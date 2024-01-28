using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{    
    public void menuScene()                     // Método para carregar cena Menu
    {
        SceneManager.LoadScene("Menu");
    }
        
    public void LoadQuefern()                   // Método para carregar cena Quefren
    {
        SceneManager.LoadScene("quefren");
    }
    
    public void LoadQueops()                    // Método para carregar cena Queops
    {
        SceneManager.LoadScene("queops");
    }
}
