using UnityEngine;

public class MoveSandy : MonoBehaviour
{
    Animator anim;

    void Start() { anim = GetComponent<Animator>(); }

    void Update()
    {
        float valX = 0f, valY = 0f;

        if (Input.GetKey(KeyCode.W)) valY = 3f;
        if (Input.GetKey(KeyCode.S)) valY = -3f;
        if (Input.GetKey(KeyCode.D)) valX = 3f;
        if (Input.GetKey(KeyCode.A)) valX = -3f;

        // Movimento
        transform.position += new Vector3(valX, valY, 0) * 0.1f;

        // Flip esquerda/direita
        if (valX != 0) transform.localScale = new Vector3(valX, 3f, 1f);

        // MANDA pro Animator
        anim.SetFloat("ValX", valX);
        anim.SetFloat("ValY", valY);
    }
}
