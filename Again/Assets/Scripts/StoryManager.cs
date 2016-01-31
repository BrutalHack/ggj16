using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class StoryManager : MonoBehaviour {

	public bool opening = true;
	public TransitionManager transitionManager;
	public Image background;
	public Text text;
	public Sprite[] storySprites;
	public string[] storyTexts;
	public AudioClip[] storyAudio;
	private int count = 0;
	private bool open = false;
	private string openTrigger = "Open";
	private string closeTrigger = "Close";

	private Animator animator;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		audio = this.gameObject.GetComponent<AudioSource> ();
		UpdateStory (count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Opened(){
		open = true;
	}

	private void UpdateStory(int count){
		background.sprite = storySprites [count];
		text.text = storyTexts [count];
		if (storyAudio [count] != null) {
			this.audio.Stop();
			this.audio.PlayOneShot (storyAudio [count]);
		}
	}

	public void Closed(){
		UpdateStory (count);
		animator.SetTrigger (openTrigger);
	}

	public void Next(){
		if(open){
			open = false;
			count++;
			if(count < storySprites.Length){
				animator.SetTrigger (closeTrigger);
			}else{
				if (opening) {
					transitionManager.StartGame ();
				} else {
					transitionManager.StartOpening ();
				}
			}
		}
	}
}
