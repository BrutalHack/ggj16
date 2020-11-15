using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ObstacleSpawner))]
public class GameControl : MonoBehaviour
{
    public static bool demo;
    public bool m_demo;
    public float duration = 60;
    private float elapsed;

    private void Awake()
    {
        demo = m_demo;
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > duration) SceneManager.LoadScene("ending");
    }

    private void OnGUI()
    {
        if (demo) GUILayout.Label("Game developed for Smartphones with Accelerometer and Swipe Input");
    }

    public void Fail()
    {
        SceneManager.LoadScene("game");
    }
}