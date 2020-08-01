using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{	
	public Animator mAnimator; // Menu animator
	public Animator cAnimator; // Controls Page animator
	
	public void StartGame(){
		transform.GetChild(4).gameObject.SetActive(true);
		StartCoroutine(LoadAsyncScene());
	}

	public void ToggleControls() {
		if (cAnimator.GetBool("controls") == false) {
			mAnimator.SetBool("menu", false);
			cAnimator.SetBool("controls", true);
		} else {
			cAnimator.SetBool("controls", false);
			mAnimator.SetBool("menu", true);
		}
	}

	public void QuitGame(){
		Debug.Log("Quit");
		Application.Quit();
	}


	// This was taken from the unity documentation
    IEnumerator LoadAsyncScene(){
        
        // while(true)
            yield return new WaitForSeconds(1f);
		transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(true);
		transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(8f);
		transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
		transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
           
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");
    }
}
