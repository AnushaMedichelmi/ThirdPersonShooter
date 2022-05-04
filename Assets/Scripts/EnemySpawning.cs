using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawning : MonoBehaviour
{
    public static EnemySpawning instance;
    public GameObject enemyPrefab;
   // public GameObject enemyRagDoll;


    public List<GameObject> Enemy = new List<GameObject>();
  // public List<GameObject> EnemyRagdoll = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        return;
    }


    // Start is called before the first frame update
    void Start()
    {

        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddToPool()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(enemyPrefab);

            Enemy.Add(temp);
            temp.SetActive(false);

        }
    }
    /*
    public void AddToRagDollPool()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject temp = Instantiate(enemyRagDoll);

            EnemyRagdoll.Add(temp);
            temp.SetActive(false);

        }
    }*/




    public GameObject EnemiesFromPool()
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (!Enemy[i].gameObject.activeInHierarchy)
            {
                Debug.Log("active");
                return Enemy[i].gameObject;

            }
        }
        return null;

    }
    /*

    public GameObject EnemiesRagDollFromPool()
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            if (!EnemyRagdoll[i].gameObject.activeInHierarchy)
            {
                Debug.Log("active");
                return EnemyRagdoll[i].gameObject;

            }
        }
        return null;

    }*/

}
