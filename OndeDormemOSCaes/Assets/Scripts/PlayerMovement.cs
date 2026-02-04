using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float jumpDuration = 0.3f;

    private Animator anim;
    private bool isJumping = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, v, 0).normalized;

        if (!isJumping)
        {
            transform.position += move * speed * Time.deltaTime;
        }

        // Animações de movimento
        anim.SetFloat("MoveX", h);
        anim.SetFloat("MoveY", v);
        anim.SetBool("IsMoving", move != Vector3.zero);

        // Flip esquerda/direita
        if (h != 0)
        {
            transform.localScale = new Vector3(h > 0 ? 1 : -1, 1, 1);
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    private System.Collections.IEnumerator Jump()
    {
        isJumping = true;
        anim.SetTrigger("Jump");

        float elapsed = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 jumpScale = new Vector3(startScale.x, 1.2f, 1f);

        // Sobe
        while (elapsed < jumpDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(startScale, jumpScale, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        // Desce
        while (elapsed < jumpDuration / 2f)
        {
            transform.localScale = Vector3.Lerp(jumpScale, startScale, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
        isJumping = false;
    }
}
