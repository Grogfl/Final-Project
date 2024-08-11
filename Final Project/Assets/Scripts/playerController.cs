using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector3 respawnPosition;
    private Rigidbody2D rb;
    public Transform landingCraft;
    public int lives = 3;
    //public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = landingCraft.position;
        //UpdateLivesText();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
            Destroy(other.gameObject); 
        }
    }

    void Die()
    {
        lives--;
        //UpdateLivesText();
        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            Debug.Log("Game Over!");
            // Implement game over logic here (e.g., showing a game over screen)
            // For now, we'll just log it
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition; // Move player back to the respawn position
    }

    // void UpdateLivesText()
    // {
    //     if (livesText != null)
    //     {
    //         livesText.text = "Lives: " + lives;
    //     }
    // }
}
