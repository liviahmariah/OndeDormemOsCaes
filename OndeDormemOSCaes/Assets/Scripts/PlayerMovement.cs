using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 LastMoveDirection => lastMoveDir;
    [Header("Movimento")]
    public float speed = 5f;

    [Header("Pulo / Dash")]
    public float jumpDistance = 1.5f;
    public float jumpDuration = 0.25f;

    private Animator anim;
    private bool isJumping;

    private Vector3 baseScale;
    private Vector2 lastMoveDir = Vector2.down; // direção padrão inicial

    void Start()
    {
        anim = GetComponent<Animator>();
        baseScale = transform.localScale;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(h, v);

        // salva a última direção válida
        if (move != Vector2.zero)
            lastMoveDir = move.normalized;

        // MOVIMENTO NORMAL
        if (!isJumping)
        {
            transform.position += (Vector3)move.normalized * speed * Time.deltaTime;
        }

        // ANIMAÇÃO DE ANDAR
        anim.SetBool("isWalking", move != Vector2.zero);

        // FLIP (somente visual, eixo X)
        if (h != 0)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(h) * Mathf.Abs(baseScale.x),
                baseScale.y,
                baseScale.z
            );
        }

        // PULO / DASH
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(Jump());
        }

        // LATIDO
        if (Input.GetKeyDown(KeyCode.E) && !isJumping)
        {
            anim.SetTrigger("isBarking");
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        anim.SetBool("isJumping", true);

        Vector3 startPos = transform.position;

        // garante direção correta do pulo
        Vector2 jumpDir = lastMoveDir;

        // se estiver parado, usa o lado que está virado
        if (jumpDir == Vector2.zero)
        {
            jumpDir = transform.localScale.x < 0 ? Vector2.left : Vector2.right;
        }

        Vector3 targetPos = startPos + (Vector3)(jumpDir.normalized * jumpDistance);

        float elapsed = 0f;

        Vector3 jumpScale = new Vector3(
            transform.localScale.x,
            baseScale.y * 1.2f,
            baseScale.z
        );

        while (elapsed < jumpDuration)
        {
            float t = elapsed / jumpDuration;

            // movimento do dash
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            // squash & stretch
            transform.localScale = Vector3.Lerp(
                baseScale,
                jumpScale,
                Mathf.Sin(t * Mathf.PI)
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        transform.localScale = baseScale;

        anim.SetBool("isJumping", false);
        isJumping = false;
    }
}
