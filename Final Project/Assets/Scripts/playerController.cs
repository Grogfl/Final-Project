using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector3 respawnPosition = new Vector3(0, -4, 0);
    private Rigidbody2D rb;
    public int lives = 3;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLives();
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
        UpdateLives();
        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Respawn()
    {
        transform.position = respawnPosition;
    }

     void UpdateLives()
     {
        if (livesText != null)
         {
             livesText.text = "Lives: " + lives;
         }
     }
}
