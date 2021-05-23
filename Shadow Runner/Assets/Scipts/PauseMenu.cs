using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
public static bool isPaused = false;
public GameObject pauseMenuUI;
public GameObject diedText;
public AudioSource PauseMusic;
public AudioSource BackGroundMusic;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused)
            {
                Resume();
            }
        else
        {
            Pause();
        }
    }

    if(Jans.isAlive == false){
        Debug.Log("diedMenuActive");
        Pause();
        diedText.SetActive(true);
    }
    if(Jans.isAlive == true){
        diedText.SetActive(false);
    }

    if(isPaused && !PauseMusic.isPlaying){
        PauseMusic.Play();
    }
    if(!isPaused){
        PauseMusic.Stop();
    }
    if(!BackGroundMusic.isPlaying){
        BackGroundMusic.Play();
    }
    }


    public void Resume(){
        if(Jans.isAlive){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        }
        if(!Jans.isAlive){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Game");
        Jans.isAlive = true;
        }
    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void Quit(){
        Application.Quit();
    }
}
