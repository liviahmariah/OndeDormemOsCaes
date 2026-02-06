using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpDuration = 0.3f;

    private Animator anim;
    private bool isJumping;

    private Vector3 baseScale;

    void Start()
    {
        anim = GetComponent<Animator>();
        baseScale = transform.localScale;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(h, v).normalized;

        if (!isJumping)
        {
            transform.position += (Vector3)move * speed * Time.deltaTime;
        }

        // ANDAR
        anim.SetBool("isWalking", move != Vector2.zero);

        // FLIP
        if (h != 0)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(h) * Mathf.Abs(baseScale.x),
                baseScale.y,
                baseScale.z
            );
        }

        // PULO
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

        float elapsed = 0f;
        Vector3 jumpScale = new Vector3(
            transform.localScale.x,
            baseScale.y * 1.2f,
            baseScale.z
        );

        while (elapsed < jumpDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(baseScale, jumpScale, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < jumpDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(jumpScale, baseScale, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = baseScale;
        anim.SetBool("isJumping", false);
        isJumping = false;
    }
}
