using UnityEngine;

public class MoveSideways : MonoBehaviour
{
    public float speed = 0.25f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}