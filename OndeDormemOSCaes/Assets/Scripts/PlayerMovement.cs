using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movimento = new Vector3(h, v, 0);
        transform.position += movimento * speed * Time.deltaTime;
    }
}
