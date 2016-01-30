using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Tilt))]
public class MoveWithInertia : MonoBehaviour
{
    private Transform target;
    private Tilt tilt;
    private float speed = 0;
    // Use this for initialization
    void Start()
    {
        tilt = GetComponent<Tilt>();
        target = GetComponent<Transform>();   
    }
	
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.acceleration.x);
        speed = speed + Input.acceleration.x;
        target.Translate(speed * Time.deltaTime, 0, 0);
        tilt.angle = speed * 10;
    }
}
