using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using NamespaceGameManager;
using NamespaceGameControl;

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
    private GameManager GameManager;
    public Camera fpsCam;
    public float range = 100f;
    private GameControl GameControl;



    // Use this for initialization
    void Start()
    {
    m_CharacterController = player.GetComponent<CharacterController>();
    firstPersonController = player.GetComponent<FirstPersonController>();
    GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    GameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
    Ammo = 4;
    shoottime = 0.0f;
    reloadtime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateShootTime();
        UpdateReloadTime();
        if(!GameControl.gameIsPaused && !GameManager.isStarting)
       {


        if(player.name == "FPSController"+firstPersonController.playerNumber && !GameManager.isFinish)
        {

            if(Input.GetButtonDown("Player"+firstPersonController.playerNumber+"Shoot"))
            {
                CheckBullet();
            }

            if(Input.GetButtonDown("Player"+firstPersonController.playerNumber+"Reload") && reloadtime <= 0)
            {
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

    private void ShootBullet()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
        Debug.Log(hit.transform.name);
        }
       GameObject impact = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));

       Rigidbody rig = impact.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
