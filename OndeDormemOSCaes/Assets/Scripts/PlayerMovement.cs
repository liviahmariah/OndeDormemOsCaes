using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, v, 0).normalized;
        transform.position += move * speed * Time.deltaTime;

        // Atualiza animações
        anim.SetFloat("MoveX", h);
        anim.SetFloat("MoveY", v);
        anim.SetBool("IsMoving", move != Vector3.zero);

        // Flip para esquerda/direita
        if (h != 0)
        {
            transform.localScale = new Vector3(h > 0 ? 1 : -1, 1, 1);
        }
    }
}
