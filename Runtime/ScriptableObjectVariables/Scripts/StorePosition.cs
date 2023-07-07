/*
File: StorePosition.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.6.2023

Description:
Stores the attached transform's position to a Vector3Variable whenever it 
changes.

Changelog:
V1.0 - Initial Documentation (7.6.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to store the attached transform's position to a 
    /// Vector3Variable whenever it changes.
    /// </summary>
    public class StorePosition : MonoBehaviour
    {
        /// <summary>
        /// The transform whose position will be written to the storage 
        /// variable.
        /// </summary>
        [Tooltip("The transform whose position will be written to the " + 
            "storage variable.")]
        [SerializeField] private Transform _trackedTransform;

        /// <summary>
        /// The storage variable to which the tracked transform's position will
        /// be stored.
        /// </summary>
        [Tooltip("The storage variable to which the tracked transform's " + 
            "position will be stored.")]
        [SerializeField] private Vector3Variable _storageVariable;

        /// <summary>
        /// Position of the transform last frame.
        /// </summary>
        private Vector3 _positionLastFrame;

        #region MonoBehaviour Methods
        private void Awake()
        {
            if (_trackedTransform == null)
            {
                _trackedTransform = transform;
            }
        }
        private void Update()
        {
            if (_trackedTransform.position != _positionLastFrame)
            {
                _storageVariable.Value = _trackedTransform.position;
                _positionLastFrame = _trackedTransform.position;
            }
        }
        #endregion
    }
}
