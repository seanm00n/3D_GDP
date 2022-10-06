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
            Instantiate(sparkEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
