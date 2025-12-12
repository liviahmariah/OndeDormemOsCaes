using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Inventory.items[itemName] += 1;
            Destroy(gameObject);
        }
    }
}
