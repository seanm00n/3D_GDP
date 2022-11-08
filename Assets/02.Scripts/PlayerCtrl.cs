using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Anim { 
    public AnimationClip Idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
    //클래스 하나 더 만드는 방법도 있음
}

public class PlayerCtrl : MonoBehaviour
{
    private float h;
    private float v;
    private float x;
    private float y;
    private float moveSpeed;
    private float rotSpeed;
    public int hp = 100;

    private Animation _animation;
    public Anim anim;
    

    private Transform tr;

    void Init()
    {
        h = 0.0f;
        v = 0.0f;
        x = 0.0f;
        y = 0.0f;

        moveSpeed = 10.0f;
        rotSpeed = 1000.0f;
    }

    void Start()
    {
        Init();
        tr = GetComponent<Transform>();
        _animation  = GetComponentInChildren<Animation>();
        _animation.clip = anim.Idle;
        _animation.Play();
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
        //
        if(v >= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.3f);
        } else if(v <= -0.1f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.3f);
        }
        else if(h >= 0.1f)
        {
            _animation.CrossFade(anim.runRight.name, 0.3f);
        }
        else if(h <= -0.1f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.Idle.name, 0.3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Punch")
        {
            hp -= 10;
            Debug.Log("Player HP = " + hp.ToString());
            if(hp <= 0)
            {
                PlayerDie();
            }
        }
    }
    void PlayerDie()
    {
        Debug.Log("Player Die!!");

        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach(GameObject monster in monsters) //foreach 성능문제 해결
        {
            monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);//
        }
    }
}
