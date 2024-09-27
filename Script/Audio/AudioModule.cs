using System;
using UnityEngine;

namespace Script.Audio
{
    public class AudioModule : MonoBehaviour
    {
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private AudioSource audioSource;
        private int _currentClipID = 1;

        private static bool isMute;

        [HideInInspector] public static bool IsMute => isMute;

        public AudioSource AudioSource => audioSource;

        private void Start()
        {
            audioSource.clip = clips[0];
            audioSource.Play();
        }

        private void FixedUpdate()
        {
            if (audioSource.isPlaying) return;
            if (audioSource.time != 0) return;

            _currentClipID++;
            if (clips.Length < _currentClipID)
            {
                _currentClipID = 1;
            }

            audioSource.clip = clips[_currentClipID - 1];
            audioSource.Play();
        }

        public void SetMuteState(bool mute)
        {
            isMute = mute;
            audioSource.mute = isMute;
        }
    }
}