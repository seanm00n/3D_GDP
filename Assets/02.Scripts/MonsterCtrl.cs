using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal;

public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;

    public GameObject bloodEffect;
    public GameObject bloodDecal;

    private int hp = 100;
    
    void Start()
    {
        monsterTr = gameObject.GetComponent<Transform>(); //���� ��ü�� tr
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>(); //�±׷� �÷��̾� tr �˻�
        nvAgent = gameObject.GetComponent<NavMeshAgent>(); //���� ��ü�� nav
        animator = gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());
    }
    IEnumerator CheckMonsterState()
    {
        while (!isDie) //��� �ִ� ����
        {
            yield return new WaitForSeconds(0.2f); //0.2�� ���߰� �Ʒ� ����
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);
            if(dist <= attackDist)
            {
                monsterState = MonsterState.attack;
            }else if(dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }else{
                monsterState = MonsterState.idle;
            }
        }
    }
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState) { 
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace", true);
                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }
    void OnPlayerDie()
    {
        StopAllCoroutines();
        nvAgent.isStopped = true;
        animator.SetTrigger("IsPlayerDie");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            hp -= collision.gameObject.GetComponent<BulletCtrl>().damage;
            if(hp <= 0)
            {
                MonsterDie();
            }
            else
            {
                animator.SetTrigger("IsHit");
            }
        }
    }
    void MonsterDie()
    {

    }
}
 