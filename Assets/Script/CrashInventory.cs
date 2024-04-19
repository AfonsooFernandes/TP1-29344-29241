using UnityEngine;
using UnityEngine.Events;

public class CrashInventory : MonoBehaviour
{
    public int NumberOfFruits { get; private set; }
    public UnityEvent<CrashInventory> OnFruitCollected;

    private void Start()
    {
        // Inicializar o número de frutas como 0 ao iniciar a cena
        NumberOfFruits = PlayerPrefs.GetInt("NumberOfFruits", 0);
    }

    public void FruitCollected()
    {
        NumberOfFruits++;
        OnFruitCollected.Invoke(this);
    }
}
