/*
File: SpriteRendererColorFader.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This script allows the user to fade the color of a SpriteRenderer in and out 
using a coroutine or an asynchronous method call.

Changelog:
V1.0 - Initial Documentation (4.28.2023)
*/

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to fade the color of an SpriteRenderer in and out 
    /// using a coroutine or an asynchronous method call.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererColorFader : Fader
    {
        /// <summary>
        /// The color of this SpriteRenderer when it is faded in.
        /// </summary>
        [Header("Fade Color")]
        [Tooltip("The color of this SpriteRenderer when it is faded in.")]
        [SerializeField] private Color _colorIn = Color.white;

        /// <summary>
        /// The color of this SpriteRenderer when it is faded out.
        /// </summary>
        [Tooltip("The color of this SpriteRenderer when it is faded out.")]
        [SerializeField] private Color _colorOut = 
            new Color(1.0f, 1.0f, 1.0f, 0.0f);

        /// <summary>
        /// Attached SpriteRenderer.
        /// </summary>
        private SpriteRenderer _spriteRenderer;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        #endregion

        #region Fader Methods
        protected override IEnumerator FadeRoutine(float fadeDuration,
            bool fadeIn, bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            Color startColor = _spriteRenderer.color;
            Color targetColor = fadeIn ? _colorIn : _colorOut;

            while (elapsedTime < fadeDuration)
            {
                _spriteRenderer.color = Color.Lerp(startColor, targetColor,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _spriteRenderer.color = targetColor;

            HandleDelegatesAndEvents(fadeIn);
        }

        protected override async Task FadeAsync(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            Color startColor = _spriteRenderer.color;
            Color targetColor = fadeIn ? _colorIn : _colorOut;

            while (elapsedTime < fadeDuration)
            {
                _spriteRenderer.color = Color.Lerp(startColor, targetColor,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            _spriteRenderer.color = targetColor;
            HandleDelegatesAndEvents(fadeIn);
        }

        public override void InImmediate()
        {
            _spriteRenderer.color = _colorIn;
        }

        public override void OutImmediate()
        {
            _spriteRenderer.color = _colorOut;
        }
        #endregion
    }
}
