using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 10;
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        //to destroy the extra cloned obstacles
        if(transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
