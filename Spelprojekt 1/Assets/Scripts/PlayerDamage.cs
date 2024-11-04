using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invincibilityTime = 2f;
    private bool invincible = false; // Moved declaration here

    void DisableInvincibility()
    {
        invincible = false; // Fixed method body syntax
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invincible)
            {
                return; // Exit if the player is invincible
            }

            if (playerHealth > 0)
            {
                playerHealth--;
                invincible = true; // Set invincible state
                Invoke("DisableInvincibility", invincibilityTime); // Corrected string quotation
                Debug.Log("Player health: " + playerHealth); // Fixed Debug.Log syntax
            }
            else
            {
                Destroy(gameObject); // Corrected destroy syntax
            }
        }
    }
}
