using System;
using System.Collections;
using Script.Yandex;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Image nextSpawnBall;
        [SerializeField] private RectTransform gameOverDialog;
        [SerializeField] private RectTransform winDialog;
        [SerializeField] private RectTransform dialogSpawnParent;
        [SerializeField] private BallsController ballsController;

        public void UpdateNextSpawnBallImage(Sprite sprite)
        {
            nextSpawnBall.sprite = sprite;
        }

        public void CreateGameOverDialog()
        {
            Instantiate(gameOverDialog, dialogSpawnParent);
        }

        public void CreateWinDialog()
        {
            Instantiate(winDialog, dialogSpawnParent);
            ballsController.SetPauseState();
        }
    }
}