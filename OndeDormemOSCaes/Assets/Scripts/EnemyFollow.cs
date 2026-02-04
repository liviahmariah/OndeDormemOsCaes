using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 1.5f;

    private Transform player;
    private Vector3 escalaOriginal;

    void Awake()
    {
        escalaOriginal = transform.localScale;
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Flip
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
        else
            transform.localScale = new Vector3(-Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
    }
}
