using UnityEngine;
using UnityEngine.UI;
using UI;
using Animation;

namespace GameLogic
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Image _imageitem;

        private AnimationItem _itemAnimation;
        public string Name { get; set; }
        public Task Task { get; set; }

        private void Awake()
        {
            _itemAnimation = GetComponent<AnimationItem>();
        }
        public void SetIcon(Sprite icon)
        {
            _imageitem.sprite = icon;
        }

        public void CheckChoise()
        {
           _itemAnimation.AnimationDistributor(Task.CheckCorrectChoise(Name));
        }
    }
}
