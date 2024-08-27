using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float upForce = 10;
    [SerializeField] float gravityModefier;
    private bool isGrounded = true;
    public bool gameOver = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModefier;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * upForce , ForceMode.Impulse);
            isGrounded = false;
           
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")){

            isGrounded=true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            //Time.timeScale = 0;
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
