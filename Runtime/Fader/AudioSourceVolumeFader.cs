/*
File: AudioSourceVolumeFader.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This script allows the user to fade the volume of an AudioSource in and out 
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
    /// Allows the user to fade the volume of an AudioSource in and out using a 
    /// coroutine or an asynchronous method call.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceVolumeFader : Fader
    {
        /// <summary>
        /// Should this CanvasGroup fade out on start?
        /// </summary>
        [Header("Volume Fade Parameters")]
        [Tooltip("Should this AudioSource volume fade in on start?")]
        [SerializeField] private bool _fadeInOnStart = true;

        /// <summary>
        /// The volume of this AudioSource when it is faded in.
        /// </summary>
        [Range(0, 1)]
        [Tooltip("The volume of this AudioSource when it is faded in.")]
        [SerializeField] private float _volumeIn = 1;

        /// <summary>
        /// The volume of this AudioSource when it is faded out.
        /// </summary>
        [Range(0, 1)]
        [Tooltip("The volume of this AudioSource when it is faded out.")]
        [SerializeField] private float _volumeOut = 0;

        /// <summary>
        /// Attached AudioSource.
        /// </summary>
        private AudioSource _audioSource;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        private void Start()
        {
            if (_fadeInOnStart)
            {
                OutImmediate();
                FadeIn();
            }
        }
        #endregion

        #region Fader Methods
        protected override IEnumerator FadeRoutine(float fadeDuration,
            bool fadeIn, bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            float startVolume = _audioSource.volume;
            float targetVolume = fadeIn ? _volumeIn : _volumeOut;

            if (dynamicFadeTime)
            {
                elapsedTime = fadeIn ? (startVolume * fadeDuration) :
                    (1 - startVolume) * fadeDuration;
            }

            while (elapsedTime < fadeDuration)
            {
                _audioSource.volume = Mathf.Lerp(startVolume, targetVolume,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _audioSource.volume = targetVolume;

            HandleDelegatesAndEvents(fadeIn);
        }

        protected override async Task FadeAsync(float fadeDuration, bool fadeIn,
            bool dynamicFadeTime)
        {
            float elapsedTime = 0.0f;
            float startVolume = _audioSource.volume;
            float targetVolume = fadeIn ? _volumeIn : _volumeOut;

            if (dynamicFadeTime)
            {
                elapsedTime = fadeIn ? (startVolume * fadeDuration) :
                    (1 - startVolume) * fadeDuration;
            }

            while (elapsedTime < fadeDuration)
            {
                _audioSource.volume = Mathf.Lerp(startVolume, targetVolume,
                    elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            _audioSource.volume = targetVolume;
            HandleDelegatesAndEvents(fadeIn);
        }

        public override void InImmediate()
        {
            _audioSource.volume = _volumeIn;
        }

        public override void OutImmediate()
        {
            _audioSource.volume = _volumeOut;
        }
        #endregion
    }
}
