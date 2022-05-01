using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = EnemySpawning.instance.EnemiesFromPool();
        //Debug.Log(temp.name);
        if (temp != null)
        {
            Debug.Log("true");
            int k = Random.Range(0, 100);

            if (k < 1)
            {

                temp.transform.position = temp.transform.position + new Vector3(Random.Range(20f, -45f), 1f, Random.Range(-6f, -15f));
                temp.SetActive(true);
                Debug.Log("active");
            }
        }

    }
}
