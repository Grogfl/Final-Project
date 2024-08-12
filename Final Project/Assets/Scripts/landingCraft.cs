using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class landingCraft : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    //public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        //UpdateHealthText();
    }

    // void UpdateHealthText()
    // {
    //     if (healthText != null)
    //     {
    //         healthText.text = "Landing Craft Health: " + currentHealth;
    //     }
    // }

    void Die()
    {
        // Implement what happens when the landing craft is destroyed
        SceneManager.LoadScene("GameOver");
        Debug.Log("Landing Craft destroyed!");
        // You can add more logic here like ending the game, showing a game over screen, etc.
    }
}
