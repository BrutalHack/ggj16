using UnityEngine;

public class BorderSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform parent;
    public float delay = 2f;
    public float xAxisPosition = 5f;
    public float xOffset = 0.75f;
    public float zSpawnPosition = 13.5f;

    public float minScale = 1f;
    public float maxScale = 1.5f;

    public float minSpawnDelay = 0.7f;
    public float maxSpawnDelay = 1.4f;

    private float wait;

    // Use this for initialization
    private void Awake()
    {
        float pointer = -10;
        while (pointer < zSpawnPosition)
        {
            spawn(pointer);
            pointer += Random.Range(0.5f, 1.0f);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        wait -= Time.deltaTime;
        if (wait < 0f)
        {
            wait = delay * Random.Range(minSpawnDelay, maxSpawnDelay);
            ;
            spawn(zSpawnPosition);
        }
    }

    private void spawn(float zPos)
    {
        var newObj = Instantiate(prefab[Random.Range(0, prefab.Length)], Vector3.zero, Quaternion.identity);
        newObj.transform.SetParent(parent, false);

        newObj.transform.localPosition = new Vector3(xAxisPosition + Random.Range(-xOffset, xOffset), 0f, zPos);
        var x = Random.Range(0, 2);
        if (x == 0) x = -1;
        var scale = Random.Range(minScale, maxScale);
        newObj.transform.localScale = new Vector3(scale * x, scale, scale);
    }
}