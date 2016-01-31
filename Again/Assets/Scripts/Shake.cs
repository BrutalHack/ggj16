using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {

	public float startSpeed = 1f;
	public float raise = 0.5f;
	public int maxSpeed = 20;
	public int frameSkip = 3;
	private int frame = 0;
	private float speed;
	private bool positiveDirektion;

	// Use this for initialization
	void Start () {
		speed = startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		if(frame >= frameSkip){
			frame = 0;
			gameObject.transform.localPosition = new Vector3 (gameObject.transform.localPosition.x + speed, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
			if (speed < 0) {
				speed *= -1;
			}
			if(speed <= maxSpeed){
				speed = (speed * raise + speed) * -1;
			}
			positiveDirektion = !positiveDirektion;
			if(!positiveDirektion){
				speed *= -1;
			}
		}
	}
}
