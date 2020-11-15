using UnityEngine;

public class MoveToFront : MonoBehaviour
{
    public float speed = 1;

    private void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}