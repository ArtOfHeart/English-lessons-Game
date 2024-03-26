using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class RestartAnamation : MonoBehaviour
    {
        [SerializeField] float _opacity, _durationFadeIn;
        [SerializeField] int _animationChangeTime;
        private Image _image;

        private void OnEnable()
        {
            _image = GetComponent<Image>();
            _image.color = new Color(_image.color.r,
                _image.color.g, _image.color.b, 0);
            FadeIn();
        }
        public void FadeIn()
        {
            _image.DOFade(_opacity, _durationFadeIn);
        }
       async public void FadeOut()
        {
            await Task.Delay(_animationChangeTime);
            _image.DOFade(0, 0.5f);
            await Task.Delay(500);
            gameObject.SetActive(false);
        }
    }
}
