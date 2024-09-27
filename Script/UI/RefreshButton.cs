using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.UI
{
    public class RefreshButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private BallsController ballsController;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            ballsController.RefreshBalls();
        }
    }
}