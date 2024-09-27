using System;
using System.Collections;
using System.Threading.Tasks;
using Script.UI;
using UnityEngine;

namespace Script.RedLine
{
    public class RedLine : MonoBehaviour
    {
        [SerializeField] private MainUI mainUI;
        [SerializeField] private BallsController ballsController;
        private bool onCooldown;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (onCooldown) return;
            var ball = collision.gameObject.GetComponent<Ball>();
            if (!ball) return;
            if (!ball.IsReadyToDetect) return;
            mainUI.CreateGameOverDialog();
            ballsController.SetPauseState();
            StartCoroutine(Cooldown());
            onCooldown = true;
        }

        private IEnumerator Cooldown()
        {
            for (;;)
            {
                if (onCooldown)
                {
                    onCooldown = false;
                    yield break;
                }

                yield return new WaitForSeconds(5);
            }
        }
    }
}