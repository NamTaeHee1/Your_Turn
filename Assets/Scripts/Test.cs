using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3[] WayPoint;
    [SerializeField] private Transform Target;
    int wayPointIndex = 0;
    void Update()
    {
        Target.LookAt(WayPoint[0]);
/*        if(Input.GetKeyDown(KeyCode.Space))
            Target.DOPath(WayPoint, 4f, PathType.CatmullRom).OnWaypointChange(CallBack);
        Target.LookAt(WayPoint[wayPointIndex]);
        Debug.Log(wayPointIndex);*/

    }

    void CallBack(int wayPoint)
    {
        wayPointIndex = wayPoint;
    }

}
