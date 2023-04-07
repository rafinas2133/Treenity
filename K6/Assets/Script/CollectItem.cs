using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject[] block;
    public GameObject[] item;
    public static int itemInv =  0;
    

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("item")){
            Destroy(collision.gameObject);
            block[itemInv].SetActive(false);
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
}
