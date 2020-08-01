using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Start() 
    {
        pauseMenu = transform.GetChild(1).gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(pauseMenu.transform.GetChild(0).gameObject);
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
            unpause();        
    }

    // Freezes time so nothing happens in the background while paused
    public void pause(){
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;       
    }

    // Unfreezes time to resume game
    public void unpause(){
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Changes scene to the main menu 
    public void exit(){
        unpause();
        transform.GetChild(4).gameObject.SetActive(true);
		StartCoroutine(LoadAsyncScene());
    }

    // This was taken from the unity documentation
    IEnumerator LoadAsyncScene(){
        
        // while(true)
            yield return new WaitForSeconds(1f);
           
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
    }
}
