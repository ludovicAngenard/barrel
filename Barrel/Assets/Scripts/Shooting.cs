using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 5f;

    AudioSource bulletAudio;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

    }

    private void ShootBullet()
    {
        GameObject cB = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
