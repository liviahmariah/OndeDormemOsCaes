using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 1.5f;
    Transform player;

    Vector3 escalaOriginal;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (player == null) return;

        // Movimento
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Flip preservando tamanho
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }
        else
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(escalaOriginal.x),
                escalaOriginal.y,
                escalaOriginal.z
            );
        }
    }
}
