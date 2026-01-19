using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text quantidadeText;

    public void AtualizarSlot(Sprite sprite, int quantidade)
    {
        if (quantidade <= 0 || sprite == null)
        {
            icon.enabled = false;
            quantidadeText.text = "";
            return;
        }

        icon.enabled = true;
        icon.sprite = sprite;
        quantidadeText.text = quantidade.ToString();
    }
}
