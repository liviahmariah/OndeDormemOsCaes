using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public Image[] slots;
    int slotAtual = 0;

    public void AdicionarItem(Sprite spriteItem)
    {
        if (slotAtual >= slots.Length) return;

        slots[slotAtual].sprite = spriteItem;
        slots[slotAtual].enabled = true;

        slotAtual++;
    }
}
