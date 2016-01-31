using UnityEngine;
using System.Collections;

public class HallucinationSpawner : MonoBehaviour {
    private GameControl control;
    public SpriteRenderer halluRenderer;
    public Sprite[] hallus;
    public float delay = 15;
    private float wait;
    public float halluTime = 3;
    private float currentHallu;
    private bool halluActive = false;
	void Awake () {
        wait = delay / 2;
	}
    void spawnHallu()
    {
        control = GetComponent<GameControl>();
        halluActive = true;
        if(GameControl.demo)
        {
            currentHallu = halluTime/2;
        }
        else
        {
            currentHallu = halluTime;
        }
        halluRenderer.gameObject.SetActive(true);
        halluRenderer.sprite = hallus[Random.Range(0, hallus.Length)];
    }
    public void killHallu(Vector2 direction)
    {   
        halluActive = false;
        halluRenderer.gameObject.SetActive(false);
    }
	void Update () {
        if (!halluActive)
        {
            wait -= Time.deltaTime;
            if (wait < 0)
            {
                spawnHallu();
                wait = delay * Random.Range(0.5f, 1f);
            }
        }
        else
        {
            currentHallu -= Time.deltaTime;
            if (currentHallu < 0)
            {
                if (GameControl.demo)
                {
                    killHallu(Vector2.up);
                }
                else
                {
                    control.Fail();
                }
            }
        }
	}
}
