using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Animator anim;
    public Transform target;
    NavMeshAgent agent;
    public static EnemyController instance;            //Singleton
   // public float currentTime;
   // public float attackTime;
   // bool isGameOver = false;

    PlayerMovement playerMovement;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }
    public enum STATE
    {
        MOVE,
        ATTACK,
        DAMAGE,
        WIN
    }
    public STATE state = STATE.MOVE;
    // Start is called before the first frame update

    void Start()
    {

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      //  playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Debug.Log(target);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.MOVE:
                Move();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            case STATE.DAMAGE:

                break;
            case STATE.WIN:
                break;
            default:
                break;
        }
    }

    public void Move()
    {
        // anim.SetBool("Run", true);
        anim.SetBool("Attack", false);
        agent.stoppingDistance = 10f;

        if (Vector3.Distance(target.position, this.transform.position) <= 20f)
        {
            agent.SetDestination(target.position);
            state = STATE.ATTACK;
        }

    }

    public void Attack()
    {
        // anim.SetBool("Run", false);
        anim.SetBool("Attack", true);
        anim.SetBool("Death", false);
        //transform.LookAt(target.transform.position);
        if (Vector3.Distance(target.position, this.transform.position) >= 10f)
        {
            state = STATE.MOVE;
        }

       
        Debug.Log("Attack");

       // AttackPlayer();
       
    }

   /* private void AttackPlayer()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime <= 0f)
        {
            playerMovement.health--;
            //GetComponent<PlayerController>().health--;
            Debug.Log(playerMovement.health);
            currentTime = attackTime;

        }

        if (playerMovement.health == 0)
        {
            isGameOver = true;
            Damage();
            // PlayerController.GameOver();
        }
    }*/

    public void Damage()
    {
        anim.SetBool("Attack", false);

        anim.SetBool("Death", true);

        Debug.Log("Dead");
    }
    public void Win()
    {

    }
}
