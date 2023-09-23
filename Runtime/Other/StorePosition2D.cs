/*
File: StorePosition.cs
Author: Brandon Lyman (blyman94)
Creation Date: 9.22.2023

Description:
Stores the attached transform's position to a Vector3Variable whenever it 
changes.

Changelog:
V1.0 - Initial Documentation (9.22.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to store the attached transform's position to a 
    /// Vector3Variable whenever it changes.
    /// </summary>
    public class StorePosition2D : MonoBehaviour
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
        [SerializeField] private Vector2Variable _storageVariable;

        /// <summary>
        /// Position of the transform last frame.
        /// </summary>
        private Vector2 _positionLastFrame;

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
            if ((Vector2)_trackedTransform.position != _positionLastFrame)
            {
                _storageVariable.Value = _trackedTransform.position;
                _positionLastFrame = _trackedTransform.position;
            }
        }
        #endregion
    }
}
