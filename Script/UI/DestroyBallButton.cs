using Script.Yandex;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.UI
{
    public class DestroyBallButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private BallsController ballsController;
        [SerializeField] private BallsSpawner ballsSpawner;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!ballsSpawner.BallsCount) return;
            ballsController.ActivateDestroyMode();
            YandexService.PlayRewardedAd();
        }
    }
}