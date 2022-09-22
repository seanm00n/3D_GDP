using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    public float dist = 10.0f;
    public float height = 3.0f;
    public float dampTraec = 20.0f;
    private Transform tr;
    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        //LateUpdate는 Update보다 적은 빈도로 호출됨
        tr.position = Vector3.Lerp(tr.position, 
                                   targetTr.position - (targetTr.forward * dist) + (Vector3.up * height),
                                   Time.deltaTime * dampTraec);
        tr.LookAt(targetTr.position);
    }
}
