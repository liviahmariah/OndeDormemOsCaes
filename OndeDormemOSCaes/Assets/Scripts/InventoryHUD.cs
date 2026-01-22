using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Image[] slots;
    int slotAtual = 0;

    public void AdicionarItem(Sprite spriteItem)
    {
        if (spriteItem == null)
        {
            Debug.LogError("Sprite do item está NULL!");
            return;
        }

        if (slots.Length == 0)
        {
            Debug.LogError("Slots NÃO atribuídos!");
            return;
        }

        if (slotAtual >= slots.Length)
        {
            Debug.Log("Inventário cheio!");
            return;
        }

        Debug.Log("Adicionando item ao slot " + slotAtual);

        slots[slotAtual].sprite = spriteItem;
        slots[slotAtual].enabled = true;

        slotAtual++;
    }
}
