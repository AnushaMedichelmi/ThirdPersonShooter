using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScripts : MonoBehaviour
{
    [SerializeField] int startingHealth;            //Declaring the health
    [SerializeField] int currentHealth;             //Declaring current health of the enemy
   // public GameObject particleEffect;
   public ParticleSystem particleEffect;
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth; 
       // particleEffect= particleEffect.GetComponent<ParticleSystem>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageMethod(int damageAmount)
    {
        currentHealth -= damageAmount;
         
       

        Debug.Log("In damage method");
        if (currentHealth <= 0)
        {
            DeathMethod();
            Debug.Log("Health :" + currentHealth);

           
        }
        Debug.Log("Health :" + currentHealth);
        
    }

    private void DeathMethod()
    {
     // particleEffect.Play();
            gameObject.SetActive(false);
        
    }
}

