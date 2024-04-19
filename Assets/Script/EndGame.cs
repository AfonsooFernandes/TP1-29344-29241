using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI mensagemFimJogo; // Referência ao objeto de texto para a mensagem de fim de jogo
    public Button botaoRecomecar; // Referência ao botão de recomeçar
    public CharacterController characterController; // Referência ao Character Controller do jogador

    void Start(){
        botaoRecomecar.gameObject.SetActive(false);
        mensagemFimJogo.gameObject.SetActive(false);
    }
    // Função chamada quando ocorre uma colisão
    private void OnTriggerEnter(Collider other)
    {

        // Verifica se o objeto que colidiu é o "crash"
        if (other.CompareTag("Player"))
        {
            ReiniciarNumeroFrutas();
            // Se sim, encerra o jogo
            EncerrarJogo();
        }
    }

    // Função para encerrar o jogo
    private void EncerrarJogo()
    {
        
        characterController.enabled = false;

        // Atualiza o texto da mensagem de fim de jogo
        mensagemFimJogo.gameObject.SetActive(true);
        botaoRecomecar.gameObject.SetActive(true);

        // Adiciona uma função ao botão de recomeçar
        botaoRecomecar.onClick.AddListener(RecomecarJogo);

    }

    // Função para recomeçar o jogo
    private void RecomecarJogo()
    {
        // Reinicie o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ReiniciarNumeroFrutas()
    {
        PlayerPrefs.SetInt("NumberOfFruits", 0);
    }
}