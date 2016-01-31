using UnityEngine;
using System.Collections;

public class Trip : MonoBehaviour {
    public GameControl controller;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("" + other.ToString());
        controller.Fail();
    }
}
