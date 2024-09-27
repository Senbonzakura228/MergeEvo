using System;
using System.Collections.Generic;
using Script.Score;
using Script.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class BallsSpawner : MonoBehaviour
    {
        [SerializeField] private Ball[] balls;
        [SerializeField] private Transform baseSpawnPosition;
        [SerializeField] private Transform maxLeftSpawnPosition;
        [SerializeField] private Transform maxRightSpawnPosition;
        [SerializeField] private MainUI mainUI;
        [SerializeField] private ScoreModule scoreModule;
        private Ball _nextSpawnBall;
        private GameObject ballsContainer;
        private bool isPause;
        private int _ballsCount;

        [HideInInspector] public bool BallsCount => _ballsCount > 0;

        private void Awake()
        {
            ballsContainer = new GameObject("BallsContainer");
            PrepareNextSpawnBall();
        }

        public void SpawnBall(float xPosition)
        {
            if (isPause) return;
            if (Time.timeScale == 0) return;
            var spawnPosition = new Vector2(0, baseSpawnPosition.position.y);
            if (maxLeftSpawnPosition.position.x + _nextSpawnBall.radius > xPosition)
            {
                //  spawnPosition.x = maxLeftSpawnPosition.position.x + _nextSpawnBall.radius;
                return;
            }
            else if (maxRightSpawnPosition.position.x - _nextSpawnBall.radius < xPosition)
            {
                //  spawnPosition.x = maxRightSpawnPosition.position.x - _nextSpawnBall.radius;
                return;
            }
            else
            {
                spawnPosition.x = xPosition;
            }

            var ball = Instantiate(_nextSpawnBall, spawnPosition, Quaternion.identity);
            ball.transform.SetParent(ballsContainer.transform);
            _ballsCount++;

            PrepareNextSpawnBall();
        }

        public void SetPauseState()
        {
            isPause = true;
        }

        public void RefreshBalls()
        {
            _ballsCount = 0;
            isPause = false;
            scoreModule.Reset();
            Destroy(ballsContainer);
            ballsContainer = new GameObject("BallsContainer");
        }

        private void PrepareNextSpawnBall()
        {
            if (balls.Length == 0) return;
            _nextSpawnBall = balls[Random.Range(0, balls.Length)];
            mainUI.UpdateNextSpawnBallImage(_nextSpawnBall.Sprite);
        }

        public void DestroyBall(Ball ball)
        {
            Destroy(ball.gameObject);
            _ballsCount--;
        }
    }
}