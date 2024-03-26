using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Animation
{
    public class TaskAnimations : MonoBehaviour
    {
        private TextMeshProUGUI _textTask;

        private void Awake()
        {
            _textTask = GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            FadeInTask();
        }
        public void FadeInTask()
        {
            DOTween.Sequence()
                .Append(_textTask.DOFade(0, 0))
                .Append(_textTask.DOFade(1, 2));
        }
    }
}
