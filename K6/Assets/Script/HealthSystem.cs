using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    
    public int maxHealth;
    public int health;
    public bool checkIsLoad = false;
    public static bool terLoad = false;
    public GameObject LoseScene;
    
    
    

    /*
        public SpriteRenderer playerSprite;
        public SpriteRenderer eye1;
        public SpriteRenderer eye2;
    */

    public Movement playerMovement;

    void Awake(){
        //Seleksi jika user nge load savenyya
        if(GameManager.isLoad){
            LoadPlayer();
            GameManager.isLoad = false;
            checkIsLoad = true;
            terLoad = true;
            
        }
    }

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
            // Scene currentScene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(currentScene.name);
            LoseScene.SetActive(true);
            
        }
    }

    //Method untuk save data dari player
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    //Method untuk ngeload save dari player
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        CollectItem.itemInv = data.itemInv;
        
    }
    
    
    
}
