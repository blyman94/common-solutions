/*
File: CanvasGroupFader.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This script allows the user to fade the alpha of a CanvasGroup in and out 
using a coroutine or an asynchronous method call. Also allows the user to 
specify the raycast blocking behaviour and interactibility of the CanvasGroup
when transitioning to each state.

Changelog:
V1.0 - Initial Documentation (4.28.2023)
V1.0.1 - Add option for CanvasGroup to start hidden (4.30.2023)
V1.0.2 - Add option for CanvasGroup to fade in on start (7.28.2023)
*/

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to fade the alpha of an CanvasGroup in and out 
    /// using a coroutine or an asynchronous method call. Also allows the user 
    /// to specify the raycast blocking behaviour and interactibility of the 
    /// CanvasGroup when transitioning to each state.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupFader : Fader
    {
        /// <summary>
        /// The alpha of this CanvasGroup when it is faded in.
        /// </summary>
        [Header("Fade Alpha")]
        [Tooltip("The alpha of this CanvasGroup when it is faded in.")]
        [SerializeField] private float _alphaIn = 1.0f;

        /// <summary>
        /// The alpha of this CanvasGroup when it is faded out.
        /// </summary>
        [Tooltip("The alpha of this CanvasGroup when it is faded out.")]
        [SerializeField] private float _alphaOut = 0.0f;

        /// <summary>
        /// Should this CanvasGroup start hidden?
        /// </summary>
        [Header("Canvas Group Parameters")]
        [Tooltip("Should this CanvasGroup start hidden?")]
        [SerializeField] private bool _startHidden = false;

        /// <summary>
        /// Should this CanvasGroup fade in on start?
        /// </summary>
        [Tooltip("Should this CanvasGroup fade in on start?")]
        [SerializeField] private bool _fadeInOnStart = false;

        /// <summary>
        /// Should this CanvasGroup fade out on start?
        /// </summary>
        [Tooltip("Should this CanvasGroup fade out on start?")]
        [SerializeField] private bool _fadeOutOnStart = false;

        /// <summary>
        /// When faded in, should this CanvasGroup be interactable?
        /// </summary>
        [Tooltip("When faded in, should this CanvasGroup be interactable?")]
        [SerializeField] private bool _interactableIn = true;

        /// <summary>
        /// When faded in, should this CanvasGroup block raycasts?
        /// </summary>
        [Tooltip("When faded in, should this CanvasGroup block raycasts?")]
        [SerializeField] private bool _blocksRaycastsIn = true;

        /// <summary>
        /// When faded out, should this CanvasGroup be interactable?
        /// </summary>
        [Tooltip("When faded in, should this CanvasGroup be interactable?")]
        [SerializeField] private bool _interactableOut = false;

        /// <summary>
        /// When faded out, should this CanvasGroup block raycasts?
        /// </summary>
        [Tooltip("When faded in, should this CanvasGroup block raycasts?")]
        [SerializeField] private bool _blocksRaycastsOut = false;

        /// <summary>
        /// Attached CanvasGroup.
        /// </summary>
        private CanvasGroup _canvasGroup;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            if (_startHidden || _fadeInOnStart)
            {
                OutImmediate();
            }

            if (_fadeOutOnStart)
            {
                InImmediate();
                FadeOut();
            }
            else if (_fadeInOnStart)
            {
                FadeIn();
            }
        }
        #endregion

        #region Fader Methods
        public override IEnumerator FadeRoutine(float fadeDuration,
            bool fadeIn, bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            float startAlpha = _canvasGroup.alpha;
            float targetAlpha = fadeIn ? _alphaIn : _alphaOut;

            if (dynamicFadeTime)
            {
                elapsedTime = fadeIn ? (startAlpha * fadeDuration) :
                    (1 - startAlpha) * fadeDuration;
            }

            if (fadeIn)
            {
                _canvasGroup.interactable = _interactableIn;
                _canvasGroup.blocksRaycasts = _blocksRaycastsIn;
            }

            while (elapsedTime < fadeDuration)
            {
                _canvasGroup.alpha = Mathf.Lerp(startAlpha,
                    targetAlpha, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _canvasGroup.alpha = targetAlpha;

            HandleDelegatesAndEvents(fadeIn);

            if (!fadeIn)
            {
                _canvasGroup.interactable = _interactableOut;
                _canvasGroup.blocksRaycasts = _blocksRaycastsOut;
            }
        }

        public override async Task FadeAsync(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            float startAlpha = _canvasGroup.alpha;
            float targetAlpha = fadeIn ? _alphaIn : _alphaOut;

            if (dynamicFadeTime)
            {
                elapsedTime = fadeIn ? (startAlpha * fadeDuration) :
                    (1 - startAlpha) * fadeDuration;
            }

            if (fadeIn)
            {
                _canvasGroup.interactable = _interactableIn;
                _canvasGroup.blocksRaycasts = _blocksRaycastsIn;
            }

            while (elapsedTime < fadeDuration)
            {
                _canvasGroup.alpha = Mathf.Lerp(startAlpha,
                    targetAlpha, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            _canvasGroup.alpha = targetAlpha;

            HandleDelegatesAndEvents(fadeIn);

            if (!fadeIn)
            {
                _canvasGroup.interactable = _interactableOut;
                _canvasGroup.blocksRaycasts = _blocksRaycastsOut;
            }
        }

        public override void InImmediate()
        {
            _canvasGroup.alpha = _alphaIn;
            _canvasGroup.interactable = _interactableIn;
            _canvasGroup.blocksRaycasts = _blocksRaycastsIn;
        }

        public override void OutImmediate()
        {
            _canvasGroup.alpha = _alphaOut;
            _canvasGroup.interactable = _interactableOut;
            _canvasGroup.blocksRaycasts = _blocksRaycastsOut;
        }
        #endregion
    }
}
