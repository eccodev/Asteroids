using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed = 500.0f;

    public float maxLifetime = 10.0f;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
