using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed = 25f;
    Rigidbody myRigidBody;
    Vector3 velocity; 
    Renderer _renderer;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        myRigidBody.velocity = Vector3.up * speed;
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = myRigidBody.velocity.normalized * speed;
        velocity = myRigidBody.velocity;

        if(!_renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        myRigidBody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}
