using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.UI
{
    public class RefreshGameOverButton : RefreshButton
    {
        [SerializeField] private GameObject gameOverDialog;

        public override void OnPointerClick(PointerEventData eventData)
        {
            GameObject.Find("BallsModule").GetComponent<BallsController>().RefreshBalls();
            Destroy(gameOverDialog);
        }
    }
}