using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Transform TankTransform;
    Animator TankAnimator;
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private float RotateSpeed = 10.0f;
    [SerializeField] private GameObject CannonBall, ShootPosition, GunPosition;
    private float h, v;
    bool isOnePersonView = false;
    [SerializeField] private GameObject ThreePersonView, OnePersonView;

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
        TankShooting();
        ChangePointOfView();
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
        TankTransform.Rotate(Vector3.up * (v == -1 ? -h : h)* RotateSpeed * Time.deltaTime);
    }

    void SeeOnePersonView()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, OnePersonView.transform.position, Time.deltaTime * 2);
        Camera.main.transform.rotation = OnePersonView.transform.rotation;
    }

    void SeeThreePersonView()
    {
        Camera.main.transform.position = ThreePersonView.transform.position;
        Camera.main.transform.rotation = ThreePersonView.transform.rotation;
    }

    void ChangePointOfView()
    {
        if (Input.GetMouseButtonDown(1))
            isOnePersonView = !isOnePersonView;

        if (isOnePersonView)
            SeeOnePersonView();
        else
            SeeThreePersonView();
    }

    void TankAnimationControl()
    {
        TankAnimator.SetInteger("v", (int)v);
        TankAnimator.SetInteger("h", (int)h);
    }

    void TankShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(CannonBall, OnePersonView.transform.position, Quaternion.Euler(0, 90, 0));
        }
    }
}
