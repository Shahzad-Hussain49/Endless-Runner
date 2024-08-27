using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody rb;
    private Animator playerAnim;

    [SerializeField] float upForce = 10;
    [SerializeField] float gravityModefier;
    private bool isGrounded = true;
    public bool gameOver = false;

    [Header("Audios")]
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    [Header("Partice System")]
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModefier;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            rb.AddForce(Vector3.up * upForce , ForceMode.Impulse);
            isGrounded = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticel.Stop();
            playerAudio.PlayOneShot(jumpSound);
           
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")){

            isGrounded=true;
            dirtParticel.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            //Time.timeScale = 0;
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticel.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }
}
