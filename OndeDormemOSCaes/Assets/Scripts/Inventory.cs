using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Dictionary<string, int> items = new Dictionary<string, int>()
    {
        {"graveto", 0},
        {"pedra", 0},
        {"caco", 0}
    };

    // Só para testar se está funcionando
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Graveto: " + items["graveto"]);
            Debug.Log("Pedra: " + items["pedra"]);
            Debug.Log("Caco: " + items["caco"]);
        }
    }
}
