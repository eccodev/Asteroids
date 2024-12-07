using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSystem : MonoBehaviour
{
    public GameObject prefab;
    PhysicsObject[] physicsObjects = new PhysicsObject[11];

    void Start()
    {
        for (int i = 0; i < physicsObjects.Length; i++)
        {
            PhysicsObject obj = Instantiate(prefab).GetComponent<PhysicsObject>();
            obj.transform.position = new Vector3(-10.0f + i * 2.0f, 0.0f);

            float ballx = Random.Range(2f, 5f);
            float bally = Random.Range(3f, 7f);
            float ballspeed = Random.Range(1f, 8f);
            obj.Velocity = new Vector2(Mathf.Cos(ballx), Mathf.Sin(bally)) * ballspeed;

            physicsObjects[i] = obj;
        }
    }

    void Update()
    {
        foreach (PhysicsObject obj in physicsObjects)
        {

        }
    }
}
