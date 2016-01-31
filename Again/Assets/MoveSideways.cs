using UnityEngine;
using System.Collections;

public class MoveSideways : MonoBehaviour {

    public float speed = 0.25f;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime,0,0);

    }
}
