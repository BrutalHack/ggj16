using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[RequireComponent (typeof(ObstacleSpawner))]
public class GameControl : MonoBehaviour {
    public static bool demo = false;
    public bool m_demo = false;
    public float duration = 60;
    private float elapsed = 0;
    void Awake()
    {
        demo = m_demo;
    }
    void OnGUI()
    {
        if (demo)
        {
            GUILayout.Label("Game developed for Smartphones with Accelerometer and Swipe Input");
        }
    }
    void Update () {
        elapsed += Time.deltaTime;
        if (elapsed > duration)
        {
            SceneManager.LoadScene("ending");
        }
	}
    public void Fail()
    {
        SceneManager.LoadScene("game");
    }
}
