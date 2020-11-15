using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public float delay = 5f;
    public float maxXAxisOffset = 4f;
    public float zSpawnPosition = 13.5f;
    private float wait;

    private void Update()
    {
        wait -= Time.deltaTime;
        if (wait < 0f)
        {
            var x = Random.Range(-maxXAxisOffset, maxXAxisOffset);
            wait = delay;
            var newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObj.transform.SetParent(parent, false);
            newObj.transform.localPosition = new Vector3(x, 0f, zSpawnPosition);
        }
    }
}