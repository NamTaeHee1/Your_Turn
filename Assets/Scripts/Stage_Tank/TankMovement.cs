using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Transform TankTransform;
    Animator TankAnimator;
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private float RotateSpeed = 10.0f;
    private float h, v;

    void Start() 
    { 
        TankTransform = GetComponent<Transform>();
        TankAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        GetAxis();
        TankMove();
        TankRotate();
        TankAnimationControl();
    }

     void GetAxis()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void TankMove()
    {
        TankTransform.Translate(new Vector3(v, 0, 0).normalized * MoveSpeed * Time.deltaTime);
    }

    void TankRotate()
    {
        TankTransform.Rotate(Vector3.up * h* RotateSpeed * Time.deltaTime);
    }

    void TankAnimationControl()
    {
        TankAnimator.SetInteger("v", (int)v);
        TankAnimator.SetInteger("h", (int)h);
    }
}
