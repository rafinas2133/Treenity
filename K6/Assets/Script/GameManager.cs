using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject saveUI;
    public GameObject HowToPlayUI;
    public AudioMixer audioMixer;
    public Slider volSlider = null;
    public static bool gameMenuIsActive = false;
    public static bool isLoad = false;
    public static bool isHard = false;
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
    public void NewGameHard(){
        isHard = true;
        SceneManager.LoadScene(1);
        isLoad = false;
    }
    public void MainMenu(){
        isHard = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameMenuIsActive = false;
    }
    public void LoadGame(){
        PlayerData data = SaveSystem.LoadPlayer();
        isLoad = true;
        SceneManager.LoadScene(1);
    }
    
    public void HowToPlay(){
        HowToPlayUI.SetActive(true);
        Time.timeScale = 1f;
        gameMenuIsActive = false;
    }

    public void back_btn(){
        HowToPlayUI.SetActive(false);
    }
    public void Quit(){
        Application.Quit();
    }

    public void setVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }
}
