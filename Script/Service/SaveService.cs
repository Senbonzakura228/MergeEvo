using System;
using UnityEngine;
using YG;

namespace Script.Yandex
{
    public class SaveService : MonoBehaviour
    {
        private SavesYG _currentCurrentSaved;

        [HideInInspector] public SavesYG CurrentSavedData => _currentCurrentSaved;

        private void OnEnable()
        {
            YandexGame.GetDataEvent += LoadData;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
            {
                LoadData();
            }
        }

        public void SaveScore(int score)
        {
            YandexGame.savesData.score = score;
            YandexGame.SaveProgress();
        }

        private void LoadData()
        {
            _currentCurrentSaved = YandexGame.savesData;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= LoadData;
        }
    }
}