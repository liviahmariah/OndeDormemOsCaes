using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> itens = new List<string>();

    public void AdicionarItem(string item)
    {
        itens.Add(item);
        Debug.Log("Inventário: " + itens.Count + " itens");
    }
}
