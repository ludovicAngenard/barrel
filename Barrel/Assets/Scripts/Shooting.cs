using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shooting : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public int Ammo;
    public GameObject player;
    private CharacterController m_CharacterController;
    public float reloadtime;
    public float shoottime;
    private FirstPersonController firstPersonController;



    // Use this for initialization
    void Start()
    {
    m_CharacterController = player.GetComponent<CharacterController>();
    firstPersonController = player.GetComponent<FirstPersonController>();
    Ammo = 4;
    shoottime = 0.0f;
    reloadtime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateShootTime();
        UpdateReloadTime();

        if(player.name == "FPSController"+firstPersonController.playerNumber)
        {

            if(Input.GetButtonDown("Shoot"+firstPersonController.playerNumber))
            {
                CheckBullet();
            }

            if(Input.GetButtonDown("Reload"+firstPersonController.playerNumber) && reloadtime <= 0)
            {
                Reload();
            }

        }

    }
    void UpdateShootTime(){
        if ( shoottime > 0.0f)
        {
            shoottime -= Time.deltaTime;
        }
    }
    void UpdateReloadTime(){
         if ( reloadtime > 0.0f)
        {
            reloadtime -= Time.deltaTime;
        }
    }

    void CheckBullet()
    {
        if(Ammo > 0 && shoottime <= 0 && reloadtime <= 0)
        {
            Shoot();
            Ammo = Ammo - 1;
            shoottime = 1.0f;

            if(Ammo == 0)
            {
                Reload();

            }

        }
    }

    void Shoot()
    {

        ShootBullet();
        shoottime = 1;

    }

    void Reload()
    {
        Ammo = 4;
        reloadtime = 4;
    }

    private void ShootBullet()
    {
        GameObject cB = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
