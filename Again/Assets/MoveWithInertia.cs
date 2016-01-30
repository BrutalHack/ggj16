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
        speed = speed + Input.acceleration.x;
        target.Translate(speed * Time.deltaTime, 0, 0,Space.World);
        if (target.position.x > 3.25f)
        {
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
        }else if(target.position.x < -3.25f){
            target.position = new Vector3(0, target.position.y, target.position.z);
            speed = 0;
        }
        tilt.angle = speed * 10;
    }
}
