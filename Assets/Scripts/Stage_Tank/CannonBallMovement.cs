using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{
    Rigidbody CannonBallRigidbody;
    Transform CannonBallTransform;
    [SerializeField] private float MoveSpeed = 10.0f;

    void Start() 
    {
        CannonBallTransform = GetComponent<Transform>();
        CannonBallRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CannonBallRigidbody.isKinematic = false;
        CannonBallTransform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
