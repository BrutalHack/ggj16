using UnityEngine;
using System.Collections;

public class MoveToFront : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
