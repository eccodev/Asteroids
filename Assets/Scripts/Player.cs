using UnityEngine;

public class Player : MonoBehaviour
{

    public Bullet bulletPrefab;

    public float thrustSpeed = 1.5f;

    public float turnSpeed = 0.25f;

    private Rigidbody2D _rigidbody;

    private bool thrusting;

    private float turnDirection;

    Vector2 direction = Vector2.zero;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.position = Vector3.zero;
        
    }

    private void Update()
    {

        // Movement
        thrusting = (Input.GetKey(KeyCode.W));
        if (Input.GetKey(KeyCode.A))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }
        // Shootment
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    private void FixedUpdate()
    {
        if (thrusting)
        {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }

        if (turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}