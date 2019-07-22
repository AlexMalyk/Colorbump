using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class AudioToggle : MonoBehaviour
    {
        [Header("Images")]
        [SerializeField] private Image imageOn;
        [SerializeField] private Image imageOff;

        [Header("Sprites")]
        [SerializeField] private Sprite spriteOnDisabled;
        [SerializeField] private Sprite spriteOnSelected;

        [SerializeField] private Sprite spriteOffDisabled;
        [SerializeField] private Sprite spriteOffSelected;

        public void Set(bool status)
        {
            if (status)
                SetSprites(spriteOnSelected, spriteOffDisabled);
            else
                SetSprites(spriteOnDisabled, spriteOffSelected);
        }

        private void SetSprites(Sprite spriteOn, Sprite spriteOff)
        {
            imageOn.sprite = spriteOn;
            imageOff.sprite = spriteOff;
        }
    }
}