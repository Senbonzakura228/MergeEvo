using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Audio
{
    public class VolumeButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Sprite activeIcon;
        [SerializeField] private Sprite inActiveIcon;
        [SerializeField] private Image volumeImage;
        [SerializeField] private AudioModule audioModule;
        private bool _isActive;


        public void OnPointerClick(PointerEventData eventData)
        {
            _isActive = !_isActive;
            volumeImage.sprite = _isActive ? inActiveIcon : activeIcon;
            audioModule.SetMuteState(_isActive);
        }
    }
}