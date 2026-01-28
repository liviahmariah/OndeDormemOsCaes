using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject itemVisualPrefab; // o ícone que vai pro HUD

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryHUD.instance.AdicionarItem(itemVisualPrefab);
            Destroy(gameObject);
        }
    }
}
