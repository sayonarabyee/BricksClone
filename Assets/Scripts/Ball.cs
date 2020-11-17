using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [Range(1,20)][SerializeField] float speed = 4f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
    }
}
