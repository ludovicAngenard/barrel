using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public int Ammo;
    public GameObject player;
    private CharacterController m_CharacterController;
    public float reloadtime = 4.0f;
    public float shoottime = 1.0f;


    // Use this for initialization
    void Start()
    {
    m_CharacterController = player.GetComponent<CharacterController>();
  
        Ammo = 4;

    }

    // Update is called once per frame
    void Update()
    {
        

        
        if(player.name == "FPSController")
        {
            
            if(Input.GetButtonDown("Shoot"))
            {
                CheckBullet();
            }
            
            if(Input.GetButtonDown("Reload") && reloadtime <= 0)
            {
                Reload();
            }

        }

        if(player.name == "FPSController (1)")
        {

            if(Input.GetButtonDown("Shoot2"))
            {
                CheckBullet();
            }

            if(Input.GetButtonDown("Reload2") && reloadtime <= 0)
            {
                Reload();
            }
        }

        
    }

void countdown(float timeleft)
        {
            timeleft -= Time.deltaTime;
            timer(timeleft);
        }


        float timer(float timeleft)
        {
            if(timeleft <= 0)
            {
               countdown(timeleft); 
            }
            return timeleft;
        }

        void CheckBullet()
        {
            if(Ammo > 0 && timer(shoottime) <= 0)
            {
            Shoot();
            Ammo = Ammo - 1;

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
                        reloadtime -= Time.deltaTime;
                            if (reloadtime <= 0)
                        {
                        Ammo = 4;
                        reloadtime = 4;
                        }
                        
                    }

    private void ShootBullet()
    {
        GameObject cB = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
