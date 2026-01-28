using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    public static InventoryHUD instance;
    public Transform[] slots;
    private int slotAtual = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AdicionarItem(GameObject visualPrefab)
    {
        if (slots == null || slots.Length == 0)
        {
            Debug.LogError("Slots não atribuídos no InventoryHUD!");
            return;
        }

        if (slotAtual >= slots.Length)
        {
            Debug.Log("Inventário cheio!");
            return;
        }

        GameObject novoItem = Instantiate(visualPrefab, slots[slotAtual]);
        novoItem.transform.localPosition = Vector3.zero;

        slotAtual++;
    }
}
