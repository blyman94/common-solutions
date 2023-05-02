/*
File: StringBinding.cs
Author: Brandon Lyman (blyman94)
Creation Date: 5.1.2023

Description:
This script allows the user to bind the text value of a TextMeshProUGUI object
to an underlying StringVariable, such that any time the string updates, so does
the TextMeshProUGUI's text value.

Changelog:
V1.0 - Initial Documentation (5.1.2023)
*/

using TMPro;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to bind the text value of a TextMeshProUGUI object
    /// to an underlying StringVariable, such that any time the string updates, 
    /// so does the TextMeshProUGUI's text value.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class StringBinding : MonoBehaviour
    {
        /// <summary>
        /// Variable whose value will be shown in the bound text.
        /// </summary>
        [Tooltip("Variable whose value will be shown in the bound text.")]
        [SerializeField] private StringVariable _observedStringVariable;

        /// <summary>
        /// Should this binding update on start?
        /// </summary>
        [Tooltip("Should this binding update on start?")]
        [SerializeField] private bool _updateOnStart = true;

        /// <summary>
        /// Text to be updated based on observed variable.
        /// </summary>
        private TextMeshProUGUI _boundText;

        #region MonoBehaviour Methods
        private void Awake()
        {
            _boundText = GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            _observedStringVariable.ValueUpdated += UpdateBoundText;
        }
        private void Start()
        {
            if (_updateOnStart)
            {
                UpdateBoundText();
            }
        }
        private void OnDisable()
        {
            _observedStringVariable.ValueUpdated -= UpdateBoundText;
        }
        #endregion

        /// <summary>
        /// Sets the value of the bound TextMeshProUGUI's text field to the 
        /// value of the observed string variable.
        /// </summary>
        private void UpdateBoundText()
        {
            _boundText.text = _observedStringVariable.Value;
        }
    }
}
