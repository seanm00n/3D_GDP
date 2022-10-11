using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    public GameObject sparkEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            GameObject spark = (GameObject)Instantiate(sparkEffect,collision.transform.position, Quaternion.identity);
            Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);
            //duration = ������Ʈ�� ���� �ð� ��
            Destroy(collision.gameObject);
        }
    }
}
