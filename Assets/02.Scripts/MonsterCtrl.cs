using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

public class MonsterCtrl : MonoBehaviour
{
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    public float sightDistance;
    private float distance;
    void Start()
    {
        monsterTr = gameObject.GetComponent<Transform>(); //현재 객체의 tr
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>(); //태그로 플레이어 tr 검색
        nvAgent = gameObject.GetComponent<NavMeshAgent>(); //현재 객체의 nav
        animator = gameObject.GetComponent<Animator>();
        sightDistance = 10.0f;
    }
    void Update()
    {
        Trace(); 
        
    }
    void Trace()
    {
        distance = Vector3.Distance(monsterTr.position, playerTr.position);
        if(distance < sightDistance)
        {
            Debug.Log(distance);
            nvAgent.destination = playerTr.position;
            animator.SetBool("IsTrace", true);
        }
        else
        {
            nvAgent.destination = monsterTr.position; //본인 자리로 하면 멈추는 효과
            animator.SetBool("IsTrace", false);
        }     
        // TIP.거리로 계산하는 것이 리소스 적게 먹음
    }
}
