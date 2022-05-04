using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    CharacterController characterController;
    Animator animator;
    public float rotateSpeed;
    public Slider healthBar;
    public int health;
    int ammo = 50;
    int maxAmmo = 100;
    int maxMedical = 100;
    CapsuleCollider colliders;
    // public Text textHealth;


    void Start()
    {
        characterController = GetComponent<CharacterController>();      //To get the component
        animator = GetComponentInChildren<Animator>();
        colliders = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;        //Movement of the player in horizontal direction
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        Vector3 movement = new Vector3(inputX, 0f, inputZ);
        //characterController.SimpleMove(movement*Time.deltaTime);
        animator.SetFloat("Speed", movement.magnitude);                //To make player from idle to run
        /* if (movement.magnitude > 0f)
         {
             Quaternion tempDirection = Quaternion.LookRotation(movement);
             transform.rotation = Quaternion.Slerp(transform.rotation, tempDirection, Time.deltaTime * rotateSpeed);
         }*/
        transform.Rotate(Vector3.up, inputX * rotateSpeed * Time.deltaTime);      //Rotation of the player
        if (inputZ != 0)
        {
            characterController.SimpleMove(transform.forward * Time.deltaTime * inputZ);    //Movement of the player using Simple move 
        }

         healthBar.value = (float)health/40f;
       // textHealth.text ="Health: "+ health.ToString();
    }

    public void GameOver()
    {

    }

    public void DamagePlayer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            ammo = Mathf.Clamp(ammo + 20, 0, maxAmmo);
            Debug.Log("Collected ammo");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Medical")
        {
            health = Mathf.Clamp(health + 20, 0, maxMedical);
            Debug.Log("Collected health");
            Destroy(collision.gameObject);
        }
    }
}
