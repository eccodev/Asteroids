using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public Vector2 Velocity { get; set; }

    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;

        if (transform.position.x < -10.0f || transform.position.x > 10.0f)
        {
            Velocity = new Vector2(-Velocity.x, Velocity.y);
        }
        if (transform.position.y < -5.0f || transform.position.y > 5.0f)
        {
            Velocity = new Vector2(Velocity.x, -Velocity.y);
        }
    }
}
// We can use this code as a baseline for how the asteriods can move in an unpredictable nature, we just need to add the proper control and collision