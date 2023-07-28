/*
File: Fader.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This abstract class contains generalized methods that allow its extending 
classes to fade various elements in and out.

Changelog:
V1.0 - Initial Documentation (4.28.2023)
V1.0.1 - Make underlying coroutines public (6.1.2023)
V1.0.2 - Make fade duration public (7.2.2023)
V1.0.3 - Add FadeIn(float duration) and FadeOut(float duration) methods (7.28.2023)
*/

using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Contains generalized methods that allow its extending classes to fade 
    /// various elements in and out.
    /// </summary>
    public abstract class Fader : MonoBehaviour
    {
        /// <summary>
        /// Delegate to signal that the element has finished fading in.
        /// </summary>
        public FadeFinished FadeInFinished;

        /// <summary>
        /// Delegate to signal that the element has finished fading out.
        /// </summary>
        public FadeFinished FadeOutFinished;

        /// <summary>
        /// How long will the fade will take?
        /// </summary>
        [Header("Fade Timing")]
        [Tooltip("How long will the fade will take?")]
        public float FadeDuration = 2.0f;

        /// <summary>
        /// Shortens the fade duration if the volume is already partially faded.
        /// </summary>
        [Tooltip("Shortens the fade duration if the volume is already " +
            "partially faded.")]
        [SerializeField] private bool _dynamicFadeTime = true;

        /// <summary>
        /// Should events be invoked at the end of fades?
        /// </summary>
        [Header("Fade Events")]
        [Tooltip("Should events be invoked at the end of fades?")]
        [SerializeField] protected bool _useFadeEvents = true;

        /// <summary>
        /// Event invoked at the end of a fade in.
        /// </summary>
        [Tooltip("Event invoked at the end of a fade in.")]
        [SerializeField] protected UnityEvent _onFadeInFinished;

        /// <summary>
        /// Event invoked at the end of a fade out.
        /// </summary>
        [Header("Fade Events")]
        [Tooltip("Event invoked at the end of a fade out.")]
        [SerializeField] protected UnityEvent _onFadeOutFinished;

        /// <summary>
        /// Current active coroutine.
        /// </summary>
        private Coroutine _activeCoroutine;

        /// <summary>
        /// Invokes the FadeInFinished or FadeOutFinished delegates based on the
        /// which has occurred. If the Fader uses fade events, invokes the 
        /// corresponding UnityEvent as well.
        /// </summary>
        /// <param name="fadeIn">Has this Fader finished fading in?</param>
        protected void HandleDelegatesAndEvents(bool fadeIn)
        {
            if (fadeIn)
            {
                FadeInFinished?.Invoke();
            }
            else
            {
                FadeOutFinished?.Invoke();
            }

            if (_useFadeEvents)
            {
                if (fadeIn)
                {
                    _onFadeInFinished?.Invoke();
                }
                else
                {
                    _onFadeOutFinished?.Invoke();
                }
            }
        }

        /// <summary>
        /// Fades the fadeable element from its current state to its fadeIn 
        /// state using a coroutine.
        /// </summary>
        public void FadeIn()
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(FadeDuration,
                true, _dynamicFadeTime));
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeIn state using a coroutine.
        /// </summary>
        public void FadeIn(float fadeDuration)
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(fadeDuration,
                true, _dynamicFadeTime));
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeIn state using a coroutine.
        /// </summary>
        public void FadeIn(float fadeDuration, bool dynamicFadeTime = true)
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(fadeDuration,
                true, dynamicFadeTime));
        }

        /// <summary>
        /// Fades the fadeable element from its current state to its fadeIn 
        /// state using an asynchronous method. NOTE: In February 2023 
        /// aysnchronous methods are not supported in WebGL builds. Please use 
        /// with caution if building to WebGL.
        /// </summary>
        public async Task FadeInAsync()
        {
            await FadeAsync(FadeDuration, true, _dynamicFadeTime);
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeIn state using an asynchronous method. NOTE: In February 2023 
        /// aysnchronous methods are not supported in WebGL builds. Please use 
        /// with caution if building to WebGL.
        /// </summary>
        public async Task FadeInAsync(float fadeDuration, 
            bool dynamicFadeTime = true)
        {
            await FadeAsync(fadeDuration, true, dynamicFadeTime);
        }

        /// <summary>
        /// Fades the fadeable element from its current state to its fadeOut 
        /// state using a coroutine.
        /// </summary>
        public void FadeOut()
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(FadeDuration,
                false, _dynamicFadeTime));
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeOut state using a coroutine.
        /// </summary>
        public void FadeOut(float fadeDuration)
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(fadeDuration,
                false, _dynamicFadeTime));
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeOut state using a coroutine.
        /// </summary>
        public void FadeOut(float fadeDuration, 
            bool dynamicFadeTime = true)
        {
            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
            _activeCoroutine = StartCoroutine(FadeRoutine(fadeDuration,
                false, dynamicFadeTime));
        }

        /// <summary>
        /// Fades the fadeable element from its current state to its fadeOut 
        /// state using an asynchronous method. NOTE: In February 2023 
        /// aysnchronous methods are not supported in WebGL builds. Please use 
        /// with caution if building to WebGL.
        /// </summary>
        public async Task FadeOutAsync()
        {
            await FadeAsync(FadeDuration, false, _dynamicFadeTime);
        }

        /// <summary>
        /// Overload. Fades the fadeable element from its current state to its 
        /// fadeOut state using an asynchronous method. NOTE: In February 2023 
        /// aysnchronous methods are not supported in WebGL builds. Please use 
        /// with caution if building to WebGL.
        /// </summary>
        public async Task FadeOutAsync(float fadeDuration, 
            bool dynamicFadeTime = true)
        {
            await FadeAsync(fadeDuration, false, dynamicFadeTime);
        }

        /// <summary>
        /// Sets the faded element to its fadeIn state immediately.
        /// </summary>
        public abstract void InImmediate();

        /// <summary>
        /// Sets the faded element to its fadeOut state immediately.
        /// </summary>
        public abstract void OutImmediate();

        /// <summary>
        /// Uses an asynchronous task to fade the element from its current state 
        /// to its in or out state.
        /// </summary>
        /// <returns>Task method progress.</returns>
        public abstract Task FadeAsync(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime);

        /// <summary>
        /// Uses a coroutine to fade the element from its current state to its 
        /// in or out state.
        /// </summary>
        /// <returns>IEnumerator method progress.</returns>
        public abstract IEnumerator FadeRoutine(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime);
    }
}
