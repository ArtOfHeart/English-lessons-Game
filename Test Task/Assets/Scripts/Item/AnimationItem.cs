using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

namespace Animation
{
    public class AnimationItem : MonoBehaviour
    {
        [SerializeField] Transform _itemTransform;
        [SerializeField] ParticleSystem _starParticle;

        private Vector2 _currentPosition;
        private Button _button;
        private bool _isPlaying;
        private float _animationTime = 0.6f;
        private void Start()
        {
            _button = GetComponent<Button>();
        }
        public void AnimationDistributor(bool choiseCorrect)
        {
            if (choiseCorrect && !_isPlaying)
                StartCoroutine(AnimationBounce());
            else if (!choiseCorrect && !_isPlaying)
                StartCoroutine(AnimationEaseInBounce());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        private IEnumerator AnimationBounce()
        {
            _button.enabled = false;
            _starParticle.Play();
            _isPlaying = true;
            DOTween.Sequence()
                   .Append(_itemTransform.DOScale(1f, 0.2f))
                   .Append(_itemTransform.DOScale(0.6f, 0.2f))
                   .Append(_itemTransform.DOScale(0.8f, 0.2f));
            yield return new WaitForSeconds(_animationTime);
            _isPlaying = false;
        }
        private IEnumerator AnimationEaseInBounce()
        {
            _isPlaying = true;
            _currentPosition = _itemTransform.position;
            DOTween.Sequence()
                .Append(_itemTransform.DOMoveX(_itemTransform.position.x + 0.1f, 0.1f))
                .Append(_itemTransform.DOMoveX(_itemTransform.position.x - 0.1f, 0.1f))
                .Append(_itemTransform.DOMoveX(_currentPosition.x, 0.1f));
            yield return new WaitForSeconds(_animationTime);

            _isPlaying = false;
        }
    }
}
