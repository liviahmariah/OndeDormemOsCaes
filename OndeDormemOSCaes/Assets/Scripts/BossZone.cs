using UnityEngine;

public class BossZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entrou na zona do boss!");
        }
    }
}
