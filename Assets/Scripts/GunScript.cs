using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(0.5f, 1.5f)]
    float fireRate = 1f;
    [SerializeField]
    [Range(1f, 10f)]
    int damageRate = 1;
    float timer;
    public Transform firePoint;
    [SerializeField]
    ParticleSystem particleSystem;      
    public AudioSource audio;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                
                audio.Play();
                timer = 0f;
                ToFireGun();
            }
        }

    }

    private void ToFireGun()
    {
        particleSystem.Play();
        //To add audio source
        Debug.DrawRay(firePoint.position, transform.forward * 100, Color.red, 5f);
        Ray ray = new Ray(firePoint.position, transform.forward);

        RaycastHit hitInfo;                                          //RayCast Hit 
        if (Physics.Raycast(ray, out hitInfo, 1000f))
        {
            Debug.Log("In Raycast");
            //need to Shoot the enemy 
            var health = hitInfo.collider.GetComponent<EnemyScripts>();
            Debug.Log(health);
            if (health != null)
            {
                health.DamageMethod(damageRate);
            }
        }
    }
}
