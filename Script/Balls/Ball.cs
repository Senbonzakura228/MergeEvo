using System;
using Script.Audio;
using Script.Score;
using Script.UI;
using UnityEngine;

namespace Script
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D collider2D;
        [SerializeField] private int level;
        [SerializeField] private BallsStorage ballsStorage;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private int scoreFromMerge;
        private bool _isUpgrade;
        private bool isReadyToDetect;

        public Sprite Sprite => spriteRenderer.sprite;

        public bool IsUpgrade => _isUpgrade;

        public int Level => level;

        public float radius => collider2D.bounds.extents.x;

        public bool IsReadyToDetect => isReadyToDetect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (level == ballsStorage.maxBallLevel) return;
            var ball = collision.gameObject.GetComponent<Ball>();
            if (!ball) return;
            isReadyToDetect = true;
            if (ball.level != level) return;
            UpgradeBall(ball);
        }

        private void UpgradeBall(Ball otherBall)
        {
            _isUpgrade = true;
            if (otherBall.IsUpgrade) return;
            var upgradedBall = ballsStorage.GetNextLevelBall(level);
            GameObject.Find("ScoreModule").GetComponent<ScoreModule>().AddPoints(scoreFromMerge);
            var spawnPosition = Vector2.Lerp(transform.position, otherBall.transform.position,
                Vector2.Distance(transform.position, otherBall.transform.position) / 2);
            var ball = Instantiate(upgradedBall, spawnPosition, Quaternion.identity);
            ball.PlaySound();
            ball.transform.SetParent(transform.parent);
            otherBall.Destroy();
            Destroy();
        }

        public void PlaySound()
        {
            audioSource.mute = AudioModule.IsMute;
            audioSource.Play();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}