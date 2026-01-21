using UnityEngine;

public class Item : MonoBehaviour
{
    public string nomeItem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coletou: " + nomeItem);
            Destroy(gameObject);

            other.GetComponent<Inventory>().AdicionarItem(nomeItem);

        }
    }
}
