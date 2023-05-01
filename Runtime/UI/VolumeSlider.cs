/*
File: VolumeSlider.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.30.2023

Description:
This script allows the user to control one AudioMixerGroup in an audio mixer 
using a Unity UI slider.

Changelog:
V1.0 - Initial Documentation (4.30.2023)
*/

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// allows the user to control one AudioMixerGroup in an audio mixer 
    /// using a Unity UI slider.
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        /// <summary>
        /// Which AudioMixer should be updated by this slider?
        /// </summary>
        [Tooltip("Which AudioMixer should be updated by this slider?")]
        [SerializeField] private AudioMixer _audioMixer;

        /// <summary>
        /// What should the value of this slider be by default?
        /// </summary>
        [Tooltip("What should the value of this slider be by default?")]
        [SerializeField] private float _defaultVolume = 1.0f;

        /// <summary>
        /// String representing the exposed parameter of the AudioMixer that 
        /// will be updated with this slider. You can expose and name parameters 
        /// in the edit AudioMixer window.
        /// </summary>
        [Tooltip("String representing the exposed parameter of the " +
            "AudioMixer that will be updated with this slider. You can " +
            "expose and name parameters in the edit AudioMixer window.")]
        [SerializeField] private string _exposedParamString;

        /// <summary>
        /// String used to store current value in PlayerPrefs.
        /// </summary>
        private string _prefsString;

        /// <summary>
        /// Slider to control volume of the assigned AudioMixerGroup.
        /// </summary>
        private Slider _slider;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.minValue = 0.0001f;
            _prefsString = string.Format("{0}Current", _exposedParamString);
        }
        private void Start()
        {
            _slider.value = PlayerPrefs.GetFloat(_prefsString, _defaultVolume);
            UpdateVolumeMix(_slider.value);
        }
        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(UpdateVolumeMix);
        }
        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(UpdateVolumeMix);
        }
        #endregion

        /// <summary>
        /// Restores the default value of this volume slider.
        /// </summary>
        public void RestoreDefault()
        {
            _slider.value = _defaultVolume;
            UpdateVolumeMix(_defaultVolume);
        }

        /// <summary>
        /// Updates the AudioMixer to reflect the new volue of this
        /// AudioMixerGroup.
        /// <param name="value">Slider percentage</param>
        private void UpdateVolumeMix(float value)
        {
            _audioMixer.SetFloat(_exposedParamString, Mathf.Log(value) * 20);
            PlayerPrefs.SetFloat(_prefsString, value);
        }
    }
}
