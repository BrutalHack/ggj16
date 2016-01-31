using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject prefab;
    public Transform parent;
    public float delay = 5f;
    public float maxXAxisOffset = 4f;
    public float zSpawnPosition=13.5f;
    private float wait;
	// Use this for initialization
	void Start () {
        wait = delay;
	}
    public void clearSpawns()
    {
        foreach(Transform child in parent){
            Destroy(child.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
        wait -= Time.deltaTime;
        if (wait < 0f)
        {
            float x =Random.Range(-maxXAxisOffset,maxXAxisOffset);
            wait = delay;
           GameObject newObj= (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
           newObj.transform.SetParent(parent,false);
            newObj.transform.localPosition =new Vector3(x, 0f, 13.5f);
        }
	}
}
