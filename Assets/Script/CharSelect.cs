using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{    
    public GameObject[] characters;                                                 // Array para armazenar referências aos personagens        
    private int selectedCharacterIndex = 0;                                         // Inicializado como 0 para indicar o primeiro personagem    
    private int selectedSceneIndex = -1;                                            // Inicializado como -1 para indicar nenhuma cena selecionada
    
    public void SelectCharacter(int index)                                          // Método para ser chamado quando um botão de personagem é clicado
    {        
        selectedCharacterIndex = index;                                             // Define o índice do personagem selecionado
        
        Debug.Log("Personagem " + selectedCharacterIndex + " selecionado.");        // Pode adicionar feedback visual aqui, se desejado
    }
        
    public void SelectScene(int sceneIndex)                                         // Método para ser chamado quando um botão de sala é clicado
    {        
        selectedSceneIndex = sceneIndex;                                            // Define o índice da cena selecionada        
        Debug.Log("Sala " + selectedSceneIndex + " selecionada.");                  // Pode adicionar feedback visual aqui, se desejado
    }
    
    public void StartGame()                                                         // Método para ser chamado quando o botão de iniciar o jogo é clicado
    {        
        if (selectedCharacterIndex != -1 && selectedSceneIndex != -1)               // Verifica se um personagem e uma sala foram selecionados
        {            
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);        // Salva os índices do personagem e da sala selecionados
            PlayerPrefs.SetInt("SelectedScene", selectedSceneIndex);
                        
            SceneManager.LoadScene(selectedSceneIndex);                             // Carrega a cena específica com base no índice da cena
        }
        else
        {            
            Debug.Log("Selecione um personagem e uma sala antes de iniciar o jogo.");       // Adicione feedback visual ou mensagem de erro, se desejar
        }
    }
}
