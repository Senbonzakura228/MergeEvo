using System;
using Script.Yandex;
using TMPro;
using UnityEngine;
using YG;

namespace Script.Score
{
    public class ScoreModule : MonoBehaviour
    {
        [SerializeField] private SaveService saveService;
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text bestScoreText;
        private int _currentBestScore;

        private void Start()
        {
            InitializeMaxScore();
        }

        public void AddPoints(int point)
        {
            int.TryParse(currentScoreText.text, out var currentPoints);
            currentScoreText.text = (currentPoints + point).ToString();

            if (currentPoints + point > saveService.CurrentSavedData.score)
            {
                _currentBestScore = currentPoints + point;
                bestScoreText.text = "Рекорд: " + _currentBestScore;
                saveService.SaveScore(_currentBestScore);
            }
        }

        public void Reset()
        {
            YandexService.SaveBestScore(_currentBestScore);
            currentScoreText.text = 0.ToString();
        }

        private void InitializeMaxScore()
        {
            bestScoreText.text = "Рекорд: " + saveService.CurrentSavedData.score;
            _currentBestScore = saveService.CurrentSavedData.score;
        }

        private void OnDestroy()
        {
            YandexService.SaveBestScore(_currentBestScore);
        }
    }
}