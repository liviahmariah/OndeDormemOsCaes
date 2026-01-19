using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vestical");

        animator.SetFloat("Vestical", vertical);

        Vector2 movement = new Vector2(0, vertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
