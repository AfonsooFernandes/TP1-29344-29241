using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI fruitText;

    // Referência para o componente CrashInventory do jogador
    private CrashInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        // Encontrar e armazenar uma referência para o componente CrashInventory do jogador
        playerInventory = FindObjectOfType<CrashInventory>();
        
        // Atualizar o texto inicial com o número de frutas
        if (playerInventory != null)
        {
            UpdateFruitText(playerInventory);
        }
        else
        {
            // Se o jogador não tiver um inventário, o número de frutas é 0
            fruitText.text = "0";
        }
    }

    public void UpdateFruitText(CrashInventory crashInventory)
    {
        fruitText.text = crashInventory.NumberOfFruits.ToString();
    }
}
