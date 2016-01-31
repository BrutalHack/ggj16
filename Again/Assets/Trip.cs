using UnityEngine;
using System.Collections;

public class Trip : MonoBehaviour {
    public GameControl controller;
    
    void OnTriggerEnter(Collider other)
    {
        controller.Fail();
    }
}
