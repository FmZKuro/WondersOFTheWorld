using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{    
    public void menuScene()                     // M�todo para carregar cena Menu
    {
        SceneManager.LoadScene("Menu");
    }
        
    public void LoadQuefern()                   // M�todo para carregar cena Quefren
    {
        SceneManager.LoadScene("quefren");
    }
    
    public void LoadQueops()                    // M�todo para carregar cena Queops
    {
        SceneManager.LoadScene("queops");
    }
}
