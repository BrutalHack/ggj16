using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour
{
    public float angle = 0;
    private Transform tiltee;
    // Use this for initialization
    void Start()
    {
        tiltee = GetComponent<Transform>();
	
    }
	
    // Update is called once per frame
    void Update()
    {
        tiltee.rotation = Quaternion.Euler(0, 0, angle);
    }
}
