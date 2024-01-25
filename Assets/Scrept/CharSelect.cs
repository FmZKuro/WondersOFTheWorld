using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{    
    public GameObject[] characters;                                                 // Array para armazenar refer�ncias aos personagens        
    private int selectedCharacterIndex = 0;                                         // Inicializado como 0 para indicar o primeiro personagem    
    private int selectedSceneIndex = -1;                                            // Inicializado como -1 para indicar nenhuma cena selecionada
    
    public void SelectCharacter(int index)                                          // M�todo para ser chamado quando um bot�o de personagem � clicado
    {        
        selectedCharacterIndex = index;                                             // Define o �ndice do personagem selecionado
        
        Debug.Log("Personagem " + selectedCharacterIndex + " selecionado.");        // Pode adicionar feedback visual aqui, se desejado
    }
        
    public void SelectScene(int sceneIndex)                                         // M�todo para ser chamado quando um bot�o de sala � clicado
    {        
        selectedSceneIndex = sceneIndex;                                            // Define o �ndice da cena selecionada        
        Debug.Log("Sala " + selectedSceneIndex + " selecionada.");                  // Pode adicionar feedback visual aqui, se desejado
    }
    
    public void StartGame()                                                         // M�todo para ser chamado quando o bot�o de iniciar o jogo � clicado
    {        
        if (selectedCharacterIndex != -1 && selectedSceneIndex != -1)               // Verifica se um personagem e uma sala foram selecionados
        {            
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);        // Salva os �ndices do personagem e da sala selecionados
            PlayerPrefs.SetInt("SelectedScene", selectedSceneIndex);
                        
            SceneManager.LoadScene(selectedSceneIndex);                             // Carrega a cena espec�fica com base no �ndice da cena
        }
        else
        {            
            Debug.Log("Selecione um personagem e uma sala antes de iniciar o jogo.");       // Adicione feedback visual ou mensagem de erro, se desejar
        }
    }
}
