using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicAudioSource;
        [SerializeField] private AudioToggle audioToggle;

        private bool isMusicOn = true;

        public void SetMusic(bool value)
        {
            if (isMusicOn == value)
                return;

            isMusicOn = value;

            if (value)
                musicAudioSource.Play();
            else
                musicAudioSource.Stop();

            audioToggle.Set(value);
        }
    }
}