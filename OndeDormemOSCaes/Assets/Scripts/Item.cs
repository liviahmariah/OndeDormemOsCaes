using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite spriteItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<InventoryHUD>().AdicionarItem(spriteItem);
            Destroy(gameObject);
        }
    }
}
