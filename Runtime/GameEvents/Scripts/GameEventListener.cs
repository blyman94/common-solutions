/*
File: GameEventListener.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.1.2023

Description:
This script contains a the GameEventListener ScriptableObject, one of two 
scripts that comprise the core of Event-Based ScriptableObject Architecture 
(EBSOA). By placing this MonoBehaviour component on a GameObject, the user can 
specify which GameEvent the GameEventListener should be listening to, and define
it's response to the GameEvent being raised in the inspector using a UnityEvent.

Changelog:
V1.0 - Initial Documentation (4.1.2023)
*/

using UnityEngine;
using UnityEngine.Events;

namespace Blyman94.CommonSolutions
{
    public class GameEventListener : MonoBehaviour
    {
        /// <summary>
        /// GameEvent that this listener will listen to.
        /// </summary>
        [Tooltip("GameEvent that this listener will listen to.")]
        [SerializeField] private GameEvent _event;

        /// <summary>
        /// Responses to trigger when the event is raised.
        /// </summary>
        [Tooltip("Responses to trigger when the event is raised.")]
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }
        
        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        /// <summary>
        /// Responds the the assigned GameEvent's raise call by invoking a 
        /// UnityEvent.
        /// </summary>
        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
