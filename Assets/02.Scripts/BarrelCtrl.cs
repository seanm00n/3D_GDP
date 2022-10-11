using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    private Transform tr;
    private int hitCount = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if(++hitCount >= 3)
            {
                ExpBarrel();
            }
        }
    }
    void ExpBarrel()
    {
        GameObject explosion = Instantiate(expEffect, transform.position, Quaternion.identity);
        Collider[] colls = Physics.OverlapSphere(tr.position, 10.0f);
        foreach(Collider coll in colls)
        {
            Rigidbody rbody = coll.GetOrAddComponent<Rigidbody>();
            if(rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(1000.0f, tr.position, 10.0f, 300.0f);
            }
        }
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().duration);
        Destroy(gameObject, 5.0f);
    }
}
