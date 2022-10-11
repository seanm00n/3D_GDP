using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public AudioClip fireSfx;
    private AudioSource source = null;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        CreateBullet();
        source.PlayOneShot(fireSfx, 0.9f);
    }
    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
