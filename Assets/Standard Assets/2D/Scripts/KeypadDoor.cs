using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
public class KeypadDoor : Interactable

{
    public AudioSource SoundSource;
    private bool opened = false;
    GameObject loadScreen;

    private void Start() {
        loadScreen = GameObject.FindGameObjectWithTag("GUI").transform.GetChild(4).gameObject;
    }

    public void open(){
        Animator a = this.GetComponent<Animator>();
        a.enabled = true;
        SoundSource.Play();
        GameObject.Find("Player").GetComponent<Platformer2DUserControl>().freeze = false;
        opened = true;
    }

    public override void Interact()
    {
        if (opened) 
        {
            loadScreen.SetActive(true);
		    StartCoroutine(LoadAsyncScene());
        }
    }

    IEnumerator LoadAsyncScene(){
        yield return new WaitForSeconds(1f);
           
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level2");
    }
}
