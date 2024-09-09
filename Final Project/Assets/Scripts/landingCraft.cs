using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class landingCraft : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    //public Text healthText;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //UpdateHealthText();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Kaboom();
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

    void Kaboom()
    {
        SceneManager.LoadScene("GameOver");
    }
}
