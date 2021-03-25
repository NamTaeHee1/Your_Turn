using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    Transform PlayerTransform;
    float h, v;
    [SerializeField]
    float MoveSpeed = 3.0f;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        GetAxis();
        PlayerMove();
    }

    void GetAxis()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void PlayerMove()
    {
        PlayerTransform.position += new Vector3(h, 0, v) * Time.deltaTime * MoveSpeed;
    }

    void PlayerRotate()
    {
        
    }
}
