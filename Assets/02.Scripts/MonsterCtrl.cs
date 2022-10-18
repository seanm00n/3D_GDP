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
        monsterTr = gameObject.GetComponent<Transform>(); //���� ��ü�� tr
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>(); //�±׷� �÷��̾� tr �˻�
        nvAgent = gameObject.GetComponent<NavMeshAgent>(); //���� ��ü�� nav
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
            nvAgent.destination = monsterTr.position; //���� �ڸ��� �ϸ� ���ߴ� ȿ��
            animator.SetBool("IsTrace", false);
        }     
        // TIP.�Ÿ��� ����ϴ� ���� ���ҽ� ���� ����
    }
}
