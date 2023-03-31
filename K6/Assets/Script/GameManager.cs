using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject saveUI;
    public static bool gameMenuIsActive = false;
    public static bool isLoad = false;
    void Update()
    {   //Untuk menampilkan UI Pause Menu jika menekan tombol "ESC"
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameMenuIsActive){
                Resume();
            }else{
                Pause();
            }

        }
    }

    //Method untuk melakukan resume game
    public void Resume(){
        menuUi.SetActive(false);
        Time.timeScale = 1f;
        gameMenuIsActive = false;
        saveUI.SetActive(false);
    }
    
    //Method untuk melakukan pause game
    void Pause(){
        menuUi.SetActive(true);
        Time.timeScale = 0f;
        gameMenuIsActive = true;
        saveUI.SetActive(true);

    }

    //Method Method untuk Main Menu
    public void NewGame(){
        SceneManager.LoadScene(1);
        isLoad = false;
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameMenuIsActive = false;
    }
    public void LoadGame(){
        PlayerData data = SaveSystem.LoadPlayer();
        isLoad = true;
        SceneManager.LoadScene(1);
    }
}
