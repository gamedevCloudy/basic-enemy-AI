using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; 
    public GameObject player; 

    private Vector3 spawnPos; 
    private float timer = 5f; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 
        if(timer < 0)
        {
            float randX = Random.Range(-25,25);
            float randZ = Random.Range(-25,25);

            spawnPos = new Vector3(randX, 2f, randZ);

            Instantiate(enemyPrefab , spawnPos, Quaternion.identity); 
            //enemyPrefab.transform.parent = transform; 
            timer = 5f; 
        }
    }
}
