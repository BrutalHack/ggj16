using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class StoryManager : MonoBehaviour
{
    public bool opening = true;
    public TransitionManager transitionManager;
    public Image background;
    public Text text;
    public Sprite[] storySprites;
    public string[] storyTexts;
    public AudioClip[] storyAudio;

    private Animator animator;
    private new AudioSource audio;
    private readonly string closeTrigger = "Close";
    private int count;
    private bool open;
    private readonly string openTrigger = "Open";

    // Use this for initialization
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        UpdateStory(count);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Opened()
    {
        open = true;
    }

    private void UpdateStory(int count)
    {
        background.sprite = storySprites[count];
        text.text = storyTexts[count];
        if (storyAudio[count] != null)
        {
            audio.Stop();
            audio.PlayOneShot(storyAudio[count]);
        }
    }

    public void Closed()
    {
        UpdateStory(count);
        animator.SetTrigger(openTrigger);
    }

    public void Next()
    {
        if (open)
        {
            open = false;
            count++;
            if (count < storySprites.Length)
            {
                animator.SetTrigger(closeTrigger);
            }
            else
            {
                if (opening)
                    transitionManager.StartGame();
                else
                    transitionManager.StartOpening();
            }
        }
    }
}