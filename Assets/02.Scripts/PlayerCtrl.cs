using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float moveSpeed = 1.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("h" + h.ToString());
        Debug.Log("v" + h.ToString());
        Vector3 moveDir = (Vector3.forward*v) + (Vector3.right*h);
        //tr.Translate(Vector3.forward * moveSpeed * v * Time.deltaTime, Space.Self);
        //tr.Translate(Vector3.right * moveSpeed * h * Time.deltaTime, Space.Self);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
    }
}
