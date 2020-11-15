using UnityEngine;

namespace AssemblyCSharp
{
    public class SoundSpawner : MonoBehaviour
    {
        public float delay = 2f;

        public float minSpawnDelay = 0.7f;
        public float maxSpawnDelay = 1.4f;

        public AudioClip[] clips;

        private new AudioSource audio;

        private float wait;

        private void Start()
        {
            audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            wait -= Time.deltaTime;
            if (wait < 0f)
            {
                wait = delay * Random.Range(minSpawnDelay, maxSpawnDelay);
                ;
                audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            }
        }
    }
}