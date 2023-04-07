using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public GameObject[] block;
    public GameObject[] item;
    public GameObject[] storyScene;
    public static int itemInv =  0;
    public bool isDestroyed = false;
    

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("item")){
            Destroy(collision.gameObject);
            block[itemInv].SetActive(false);
            isDestroyed = true;
            GetStoryScene(itemInv);
            itemInv++;
              
        }
         
        
    }

    void Awake(){
        if(HealthSystem.terLoad){
            for (int i = 0; i < itemInv; i++)
            {
                block[i].SetActive(false);
                Destroy(item[i]);    
            }
        }
        HealthSystem.terLoad = false;
        itemInv = 0;
            
        
    }

    void GetStoryScene(int i){
        storyScene[i].SetActive(true);
        Time.timeScale = 0f;
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            storyScene[itemInv-1].SetActive(false);
            Time.timeScale = 1f;            

        }
    }

}
