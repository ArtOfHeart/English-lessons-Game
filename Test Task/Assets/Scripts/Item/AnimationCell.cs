using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class AnimationCell : MonoBehaviour
    {
        public void AnimationAppearance()
        {
            DOTween.Sequence()
                   .Append(transform.DOScale(0, 0))
                   .Append(transform.DOScale(1.3f, 0.4f))
                   .Append(transform.DOScale(0.8f, 0.2f))
                   .Append(transform.DOScale(1.05f, 0.2f));
        }
    }
}
