using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth;
    public int health;

    /*
        public SpriteRenderer playerSprite;
        public SpriteRenderer eye1;
        public SpriteRenderer eye2;
    */

    public Movement playerMovement;

    //Set nilai max health
    public void SetMaxHealth(int maxHealth) {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
    }

    //Pengurangan health sesuai nilai amount
    public void ReduceHealth(int amount) {
        this.health -= amount;
        if (this.health <= 0) {
            
            /*
                Kode untuk kematian player
                playerSprite.enabled = false;
                eye1.enabled = false;
                eye2.enabled = false;
                playerMovement.enabled = false;    
            */
        
            //Kode ulangi level --> Hanya untuk memudahkan testing
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
