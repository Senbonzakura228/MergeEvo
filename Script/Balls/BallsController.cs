using System.Collections;
using UnityEngine;

namespace Script
{
    public class BallsController : MonoBehaviour
    {
        [SerializeField] private BallsSpawner ballsSpawner;
        [SerializeField] private float clickDelay;
        private bool isOnDelay;
        private bool isDestroyMode;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isDestroyMode)
            {
                if (Input.mousePosition.y > Screen.height * 0.7) return;
                if (isOnDelay) return;
                StartCoroutine(Cooldown());
                isOnDelay = true;
                ballsSpawner.SpawnBall(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x);
            }

            if (Input.GetMouseButtonDown(0) && isDestroyMode)
            {
                Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(ray, ray);
                var ball = hit.collider?.gameObject.GetComponent<Ball>();
                if (ball != null)
                {
                    isDestroyMode = false;
                    ballsSpawner.DestroyBall(ball);
                }
            }
        }

        public void RefreshBalls()
        {
            isDestroyMode = false;
            ballsSpawner.RefreshBalls();
        }

        public void ActivateDestroyMode()
        {
            isDestroyMode = true;
        }

        public void SetPauseState()
        {
            ballsSpawner.SetPauseState();
        }

        private IEnumerator Cooldown()
        {
            for (;;)
            {
                if (isOnDelay)
                {
                    isOnDelay = false;
                    yield break;
                }

                yield return new WaitForSeconds(clickDelay);
            }
        }
    }
}