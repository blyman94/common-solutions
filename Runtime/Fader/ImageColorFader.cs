/*
File: ImageColorFader.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This script allows the user to fade a UI image in and out using a coroutine or 
an asynchronous method call.

Changelog:
V1.0 - Initial Documentation (4.28.2023)
*/

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to fade the color of an Image in and out using a 
    /// coroutine or an asynchronous method call.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class ImageColorFader : Fader
    {
        /// <summary>
        /// The color of this Image when it is faded in.
        /// </summary>
        [Header("Fade Color")]
        [Tooltip("The color of this Image when it is faded in.")]
        [SerializeField] private Color _colorIn = Color.white;

        /// <summary>
        /// The color of this Image when it is faded out.
        /// </summary>
        [Tooltip("The color of this Image when it is faded out.")]
        [SerializeField] private Color _colorOut = 
            new Color(1.0f, 1.0f, 1.0f, 0.0f);

        /// <summary>
        /// Attached UI image.
        /// </summary>
        private Image _image;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        #endregion

        #region Fader Methods
        public override IEnumerator FadeRoutine(float fadeDuration,
            bool fadeIn, bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            Color startColor = _image.color;
            Color targetColor = fadeIn ? _colorIn : _colorOut;

            while (elapsedTime < fadeDuration)
            {
                _image.color = Color.Lerp(startColor, targetColor,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _image.color = targetColor;

            HandleDelegatesAndEvents(fadeIn);
        }

        public override async Task FadeAsync(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            Color startColor = _image.color;
            Color targetColor = fadeIn ? _colorIn : _colorOut;

            while (elapsedTime < fadeDuration)
            {
                _image.color = Color.Lerp(startColor, targetColor,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            _image.color = targetColor;
            HandleDelegatesAndEvents(fadeIn);
        }

        public override void InImmediate()
        {
            _image.color = _colorIn;
        }

        public override void OutImmediate()
        {
            _image.color = _colorOut;
        }
        #endregion
    }
}
