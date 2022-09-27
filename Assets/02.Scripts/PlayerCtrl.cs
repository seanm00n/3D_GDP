using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;
    private float v;
    private float x;
    private float y;
    private float moveSpeed;
    private float rotSpeed;

    private Transform tr;

    void Init()
    {
        h = 0.0f;
        v = 0.0f;
        x = 0.0f;
        y = 0.0f;

        moveSpeed = 10.0f;
        rotSpeed = 100.0f;
    }

    void Start()
    {
        Init();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        Init();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed *= 1.5f;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed *= 0.5f;
        }

        Vector3 moveDir = (Vector3.forward*v) + (Vector3.right*h);
        Vector3 rotDir = (Vector3.up*x) + (Vector3.right*y);

        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);

        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
    }
}
