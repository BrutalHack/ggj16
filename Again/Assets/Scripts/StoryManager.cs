using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class StoryManager : MonoBehaviour {

	public Button button;
	public Image background;
	public Text text;
	public Sprite[] storySprites;
	public string[] storyTexts;
	private int count = 0;
	private bool open = false;
	private string openTrigger = "Open";
	private string closeTrigger = "Close";

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		button.gameObject.SetActive (false);
		UpdateStory (count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Opened(){
		open = true;
		button.gameObject.SetActive (true);
	}

	private void UpdateStory(int count){
		background.sprite = storySprites [count];
		text.text = storyTexts [count];
	}

	public void Closed(){
		UpdateStory (count);
		animator.SetTrigger (openTrigger);
	}

	public void Next(){
		if(open){
			open = false;
			button.gameObject.SetActive (false);
			count++;
			if(count < storySprites.Length){
				animator.SetTrigger (closeTrigger);
			}else{
				//TODO Change Scene to GameScene.
				Debug.LogWarning("Next Scene!");
			}
		}
	}
}
