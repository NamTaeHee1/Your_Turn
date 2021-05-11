using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMovement : MonoBehaviour
{
    Rigidbody CannonBallRigidbody;
    Transform CannonBallTransform;
    [SerializeField] private float MoveSpeed = 10.0f;
    [SerializeField] private GameObject ExplosionParticlePrefab;

    void Start() 
    {
        CannonBallTransform = GetComponent<Transform>();
        CannonBallRigidbody = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 10.0f);
    }

    void Update()
    {
        CannonBallRigidbody.isKinematic = false;
        CannonBallTransform.Translate(FindObjectOfType<TankMovement>().transform.forward * MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Instantiate(ExplosionParticlePrefab, this.gameObject.transform.position, Quaternion.identity), 4.0f);
        Destroy(this.gameObject);
    }
}
