using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public float delay = 1f;
    public float xSpawn = 4f;
    public float zSpawnPosition = 13.5f;
    public float scaleFactor = 1;
    private float wait;

    private void Update()
    {
        wait -= Time.deltaTime;
        if (wait < 0f)
        {
            wait = delay;
            var newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObj.transform.localPosition = new Vector3(xSpawn, Random.Range(1f, 6f), zSpawnPosition);
            if (xSpawn > 0) newObj.GetComponent<MoveSideways>().speed *= -1;
            var scale = Random.Range(0.5f, 1f) * scaleFactor;
            newObj.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}