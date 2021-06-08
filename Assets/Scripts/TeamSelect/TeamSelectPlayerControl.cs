using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelectPlayerControl : MonoBehaviour
{
    Transform PlayerTransform;
    Animator PlayerAnimator;
    private float PlayerX, PlayerZ;
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private float RunSpeed = 10.0f;
    [SerializeField] private bool isPushShift = false;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        GetAxis();
        CheckPushShift();
        PlayerMove();
        PlayerRotate();
    }

    void GetAxis()
    {
        PlayerX = Input.GetAxisRaw("Horizontal");
        PlayerZ = Input.GetAxisRaw("Vertical");
    }

    void PlayerMove()
    {
        if (PlayerX != 0 || PlayerZ != 0)
            PlayerAnimator.SetBool("isMove", true);
        else
            PlayerAnimator.SetBool("isMove", false);

        PlayerTransform.position += new Vector3(PlayerX, 0, PlayerZ).normalized * Time.deltaTime * (isPushShift ? MoveSpeed : RunSpeed);
    }

    void CheckPushShift()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isPushShift = true;
            PlayerAnimator.SetBool("isRun", true);
        }
        else
        {
            isPushShift = false;
            PlayerAnimator.SetBool("isRun", false);
        }
    }

    void PlayerRotate()
    {
        PlayerTransform.LookAt(PlayerTransform.position + new Vector3(PlayerX, 0, PlayerZ));    // WASD로 각도 회전


/*        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);    // Mouse Position 방향으로 각도 회전
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        if(GroupPlane.Raycast(CameraRay, out float rayLength))
        {
            Vector3 Point = CameraRay.GetPoint(rayLength);

            PlayerTransform.LookAt(new Vector3(Point.x, PlayerTransform.position.y, Point.z));
        }
        */
    }
}
