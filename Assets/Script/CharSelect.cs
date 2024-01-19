using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour
{
    // Array para armazenar refer�ncias aos personagens
    public GameObject[] characters;

    // Vari�vel para armazenar o personagem selecionado
    private int selectedCharacterIndex = 0; // Inicializado como 0 para indicar o primeiro personagem

    // �ndice da cena a ser carregada
    private int selectedSceneIndex = -1; // Inicializado como -1 para indicar nenhuma cena selecionada

    // M�todo para ser chamado quando um bot�o de personagem � clicado
    public void SelectCharacter(int index)
    {
        // Define o �ndice do personagem selecionado
        selectedCharacterIndex = index;

        // Pode adicionar feedback visual aqui, se desejado
        Debug.Log("Personagem " + selectedCharacterIndex + " selecionado.");
    }

    // M�todo para ser chamado quando um bot�o de sala � clicado
    public void SelectScene(int sceneIndex)
    {
        // Define o �ndice da cena selecionada
        selectedSceneIndex = sceneIndex;

        // Pode adicionar feedback visual aqui, se desejado
        Debug.Log("Sala " + selectedSceneIndex + " selecionada.");
    }

    // M�todo para ser chamado quando o bot�o de iniciar o jogo � clicado
    public void StartGame()
    {
        // Verifica se um personagem e uma sala foram selecionados
        if (selectedCharacterIndex != -1 && selectedSceneIndex != -1)
        {
            // Salva os �ndices do personagem e da sala selecionados
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
            PlayerPrefs.SetInt("SelectedScene", selectedSceneIndex);

            // Carrega a cena espec�fica com base no �ndice da cena
            SceneManager.LoadScene(selectedSceneIndex);
        }
        else
        {
            // Adicione feedback visual ou mensagem de erro, se desejar
            Debug.Log("Selecione um personagem e uma sala antes de iniciar o jogo.");
        }
    }
}
