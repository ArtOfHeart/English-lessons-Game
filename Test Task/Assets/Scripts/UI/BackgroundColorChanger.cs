using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BackgroundColorChanger : MonoBehaviour
    {
        [SerializeField] List<Color> _colors;

        private Image _imageBackground;

        private void Start()
        {
            _imageBackground = GetComponent<Image>();
            _imageBackground.color = _colors[Random.Range(0, _colors.Count)];
        }
    }

}
