using System;
using Script.Audio;
using UnityEngine;
using YG;

namespace Script.Yandex
{
    public class PauseService : MonoBehaviour
    {
        [SerializeField] private AudioModule audioModule;

        private void Awake()
        {
            // YandexGame.OpenFullAdEvent += Pause;
            YandexGame.CloseFullAdEvent += Unpause;
            YandexGame.OpenVideoEvent += Pause;
            YandexGame.CloseVideoEvent += Unpause;
        }

        public void Pause()
        {
            audioModule.AudioSource.volume = 0;
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            audioModule.AudioSource.volume = AudioModule.IsMute ? 0 : 1;
            Time.timeScale = 1;
        }

        private void OnDisable()
        {
         //   YandexGame.OpenFullAdEvent -= Pause;
            YandexGame.CloseFullAdEvent -= Unpause;
            YandexGame.OpenVideoEvent -= Pause;
            YandexGame.CloseVideoEvent -= Unpause;
        }
    }
}