using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public void startTutorialGame () {
		SceneManager.LoadScene("scene1");
	}

	public void startMyGame() {
		//SceneManager.UnloadSceneAsync ("scene2");
		SceneManager.LoadScene("scene2");
	}

	public void backToMenu() {
		SceneManager.LoadScene("Menu");
	}

}
