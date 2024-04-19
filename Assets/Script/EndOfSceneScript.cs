using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndOfSceneTrigger : MonoBehaviour
{
    private bool hasExited;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasExited && other.CompareTag("Player"))
        {
            // Armazena o aumento de velocidade desejado
            SpiderScript.SetAumentoDeVelocidade(2f);

            // Recuperar o inventário do jogador
            CrashInventory crashInventory = other.GetComponent<CrashInventory>();
            if (crashInventory != null)
            {
                // Salvar o número de frutas coletadas antes de recarregar a cena
                PlayerPrefs.SetInt("NumberOfFruits", crashInventory.NumberOfFruits);
                PlayerPrefs.Save();
            }

            // Recarregar a cena atual após um pequeno atraso para garantir que o PlayerPrefs seja salvo
            StartCoroutine(ReloadSceneWithDelay());
        }
    }

    private IEnumerator ReloadSceneWithDelay()
    {
        hasExited = true;
        yield return new WaitForSeconds(0.1f); // Pequeno atraso para garantir que PlayerPrefs seja salvo

        // Limpa o PlayerPrefs para evitar que a velocidade seja aumentada novamente
        PlayerPrefs.DeleteKey("SpiderSpeedIncrease");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
