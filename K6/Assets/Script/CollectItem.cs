using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectItem : MonoBehaviour
{
    public GameObject[] block;
    public GameObject[] item;
    public GameObject[] storyScene;
    public static int itemInv =  0;
    private bool finish = false;
    
    

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("item")){
            Destroy(collision.gameObject);
            block[itemInv].SetActive(false);
            GetStoryScene(itemInv);
            itemInv++;
              
        }

        if(collision.gameObject.CompareTag("final")){
            GetStoryScene(3);
            finish = true;
            

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
            if(finish == false){
            storyScene[itemInv-1].SetActive(false);
            Time.timeScale = 1f;
            }else if(finish == true){
                SceneManager.LoadScene(0);
                finish = false;
                Time.timeScale = 1f;
            }            

        }
    }

}
