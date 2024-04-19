using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CrashInventory crashInventory = other.GetComponent<CrashInventory>();
        if (crashInventory != null)
        {
            crashInventory.FruitCollected();
            gameObject.SetActive(false);
        }
    }
}
