using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player_controller;
using NamespaceGameManager;

public class Shooting : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public int Ammo;
    public GameObject playerObject;
    public float reloadtime;
    public float shoottime;
    public PlayerController player;
    private GameManager GameManager;
    public Camera fpsCam;
    public LineRenderer bulletTrail;
    public float range = 100f;



    // Use this for initialization
    void Start()
    {
    GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    Ammo = 4;
    shoottime = 0.0f;
    reloadtime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateShootTime();
        UpdateReloadTime();
        if(!GameManager.isStarting){
            if(playerObject.name == "PlayerParent"+player.getPlayerNumber() && !GameManager.isFinish)
            {

                //TODO SHOOT WITH NEW INPUT

                if(player.getShoot()){
                    CheckBullet();
                }

                if(player.getReload() && reloadtime <= 0){
                    Reload();
                }

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
    private void SpawnBulletTrails(Vector3 hitpoint){
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, spawnPoint.position, Quaternion.identity);
        LineRenderer lineR = bulletTrailEffect.GetComponent<LineRenderer>();
        lineR.SetPosition(0, spawnPoint.position);
        lineR.SetPosition(1, hitpoint);
        Destroy(bulletTrailEffect, 2f);
    }

    private void ShootBullet()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            //SpawnBulletTrails(hit.point);
        }
        GameObject impact = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));

        Rigidbody rig = impact.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
