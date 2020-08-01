using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerRemote : MonoBehaviour
{
    PlatformerCharacter2D player;
    public bool cameraCutsceneStartNow = false;
    public bool hitLeftCutsceneStartNow = false;
    public bool hitRightCutsceneStartNow = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {     
        if(cameraCutsceneStartNow){
            GetComponent<Platformer2DUserControl>().enabled = false;
            StartCoroutine(PlayBackupFromCameraCutscene());
            cameraCutsceneStartNow = false;
        }
         
        if(hitLeftCutsceneStartNow){
            GetComponent<Platformer2DUserControl>().enabled = false;
            StartCoroutine(PlayBackupFromMKeyCutscene(-1.0f));
            hitLeftCutsceneStartNow = false;
        }
        
        if(hitRightCutsceneStartNow){
            GetComponent<Platformer2DUserControl>().enabled = false;
            StartCoroutine(PlayBackupFromMKeyCutscene(1.0f));
            hitRightCutsceneStartNow = false;
        }
    }
    
          
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("MKeyFist"))
        {
            Debug.Log("Hit");//other.transform.GetComponent<PlayerRemote>().hitLeftCutsceneStartNow = true;
        }    
    }

    // This was taken from the unity documentation
    IEnumerator PlayBackupFromCameraCutscene()
    {
        player.Move(-CrossPlatformInputManager.GetAxis("Horizontal")*0.5f,false,false,false,false,false,false);
        yield return new WaitForSeconds(1f);
        player.Speak("That was close... I can't let that camera see me.");
        GetComponent<Platformer2DUserControl>().enabled = true;
    }

        // This was taken from the unity documentation
    IEnumerator PlayBackupFromMKeyCutscene(float direction)
    {
        player.Move(direction*2f,false,false,false,false,false,false);
        yield return new WaitForSeconds(1f);
        player.Speak("I don't want to get hit by that!");
        GetComponent<Platformer2DUserControl>().enabled = true;
    }
}
