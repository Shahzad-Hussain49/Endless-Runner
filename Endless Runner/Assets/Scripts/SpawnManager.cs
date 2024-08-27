using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Vector3 spawnPosition = new Vector3(25, 0, 0);
    [SerializeField] float startDelay = 2f;
    [SerializeField] float repeatRate = 2f;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacles()
    {
        if(playerControllerScript.gameOver==false)
        {
        Instantiate(obstaclePrefab,spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
