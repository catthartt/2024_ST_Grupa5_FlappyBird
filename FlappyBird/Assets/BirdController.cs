using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public float maxVelocityY;
    public Rigidbody2D rb2D;

    public int Points;
    public static bool GameOver;
    public static bool FirstJump;
    public GameObject gameOverScreen;
    public Animator animator;
    public AudioSource audioSource;


    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        rb2D.gravityScale = 0f;
        GameOver = false;
        FirstJump = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (rb2D.velocity.y > maxVelocityY)
                rb2D.velocity = new Vector2(0, maxVelocityY);

            if(!FirstJump)
            {
                FirstJump = true;
                rb2D.gravityScale = 1f;
            }

            audioSource.clip = jumpSound;
            audioSource.Play();
            animator.SetTrigger("FlapWings");

            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Die!!! LAME");
        GameOver = true;
        gameOverScreen.SetActive(true);
        audioSource.clip = hitSound;
        audioSource.Play();

        if (Points > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Points);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Point_zone"))
        {
            audioSource.clip = scoreSound;
            audioSource.Play(); 
            Points++;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
