using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartIntro(){
		SceneManager.LoadScene (0);
	}

	public void StartOpening(){
		SceneManager.LoadScene (1);
	}

	public void StartGame(){
		SceneManager.LoadScene (2);
	}

	public void StartEnding(){
		SceneManager.LoadScene (3);
	}
}
