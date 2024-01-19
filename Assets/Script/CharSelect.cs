using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    // Array para armazenar referências aos personagens
    public GameObject[] characters;

    // Variável para armazenar o personagem selecionado
    private int selectedCharacterIndex = 0; // Inicializado como 0 para indicar o primeiro personagem

    // Índice da cena a ser carregada
    private int selectedSceneIndex = -1; // Inicializado como -1 para indicar nenhuma cena selecionada

    // Método para ser chamado quando um botão de personagem é clicado
    public void SelectCharacter(int index)
    {
        // Define o índice do personagem selecionado
        selectedCharacterIndex = index;

        // Pode adicionar feedback visual aqui, se desejado
        Debug.Log("Personagem " + selectedCharacterIndex + " selecionado.");
    }

    // Método para ser chamado quando um botão de sala é clicado
    public void SelectScene(int sceneIndex)
    {
        // Define o índice da cena selecionada
        selectedSceneIndex = sceneIndex;

        // Pode adicionar feedback visual aqui, se desejado
        Debug.Log("Sala " + selectedSceneIndex + " selecionada.");
    }

    // Método para ser chamado quando o botão de iniciar o jogo é clicado
    public void StartGame()
    {
        // Verifica se um personagem e uma sala foram selecionados
        if (selectedCharacterIndex != -1 && selectedSceneIndex != -1)
        {
            // Salva os índices do personagem e da sala selecionados
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
            PlayerPrefs.SetInt("SelectedScene", selectedSceneIndex);

            // Carrega a cena específica com base no índice da cena
            SceneManager.LoadScene(selectedSceneIndex);
        }
        else
        {
            // Adicione feedback visual ou mensagem de erro, se desejar
            Debug.Log("Selecione um personagem e uma sala antes de iniciar o jogo.");
        }
    }
}
