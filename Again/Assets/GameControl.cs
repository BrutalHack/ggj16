using UnityEngine;
using System.Collections;
[RequireComponent (typeof(ObstacleSpawner))]
public class GameControl : MonoBehaviour {
    private ObstacleSpawner  spawner;
    public float duration = 60;
    private float elapsed = 0;
	// Use this for initialization
	void Start () {
        spawner = GetComponent<ObstacleSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
        if (elapsed > duration)
        {
            //TOdo win;
        }
	}
    public void Fail()
    {
        spawner.clearSpawns();
        elapsed = 0;
    }
}
