using UnityEngine;
using System.Collections;

public class BorderSpawner : MonoBehaviour {
    public GameObject[] prefab;
    public Transform parent;
    public float delay = 2f;
    public float xAxisPosition = 5f;
    public float xOffset = 0.75f;
    public float zSpawnPosition = 13.5f;
    private float wait = 0;
	// Use this for initialization
	void Awake () {
        float pointer = -10;    
        while (pointer < zSpawnPosition)
        {
            spawn(pointer);
            pointer += Random.Range(0.5f, 1.0f);
        }
	}

    void spawn(float zPos)
    {
        GameObject newObj = (GameObject)Instantiate(prefab[Random.Range(0,prefab.Length)], Vector3.zero, Quaternion.identity);
        newObj.transform.SetParent(parent, false);

        newObj.transform.localPosition = new Vector3(xAxisPosition + Random.Range(-xOffset, xOffset), 0f, zPos);
        int x =Random.Range(0,2);
        if(x==0){
            x=-1;
        }
        float scale =Random.Range(0.5f, 1.0f);
        newObj.transform.localScale = new Vector3(scale*x, scale, scale);
    }
	// Update is called once per frame
	void Update () {
        wait -= Time.deltaTime;
        if (wait < 0f)
        {
            wait = delay * Random.Range(0.7f, 1.4f); ;
            spawn(zSpawnPosition);
        }
	}
}
