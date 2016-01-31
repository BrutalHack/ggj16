using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class SoundSpawner : MonoBehaviour
	{
		public float delay = 2f;

		public float minSpawnDelay = 0.7f;
		public float maxSpawnDelay = 1.4f;

		public AudioClip[] clips;

		private float wait = 0;

		private AudioSource audio;

		void Start(){
			this.audio = GetComponent<AudioSource> ();
		}

		// Update is called once per frame
		void Update () {
			wait -= Time.deltaTime;
			if (wait < 0f)
			{
				wait = delay * UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay); ;
				this.audio.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)]);
			}
		}
	}
}