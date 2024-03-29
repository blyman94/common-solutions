/*
File: GameEvent.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.1.2023

Description:
This script contains a the GameEvent ScriptableObject, one of two scripts that
comprise the core of Event-Based ScriptableObject Architecture (EBSOA). This
class allows the user to create an asset-level event that can be observed from
any scene in the game. The event collects a list of "listeners" at runtime, and
when the event is raised, it calls the "OnEventRaised" method of all registered
listeners.

Changelog:
V1.0 - Initial Documentation (4.1.2023)
V1.1 - Added GameEventRaised delegate (7.26.2023)
*/

using System.Collections.Generic;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Represents an event of interest to many other classes. The Raise() 
    /// function is called when the event is triggered, signaling all listeners 
    /// to respond to a particular game event.
    /// </summary>
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// Delegate to signal that this GameEvent has been raised.
        /// </summary>
        public GameEventRaised GameEventRaised;

        /// <summary>
        /// List of listeners observing in this event. When the event is 
        /// raised, each listener's "OnEventRaised()" method will be called.
        /// </summary>
        [Tooltip("List of listeners observing in this event. When the event " + 
        "is raised, each listener's 'OnEventRaised()' method will be called.")]
        [SerializeField]
        private List<GameEventListener> _listeners =
            new List<GameEventListener>();

        /// <summary>
        /// Calls the OnEventRaised method of all registered listeners in 
        /// reverse order. The reverse order allows listeners to be removed from 
        /// the listener list as a result of a raised event.
        /// </summary>
        public void Raise()
        {
            if (_listeners.Count > 0)
            {
                for (int i = _listeners.Count - 1; i >= 0; i--)
                {
                    _listeners[i].OnEventRaised();
                }
            }
            GameEventRaised?.Invoke();
        }

        /// <summary>
        /// Adds a listener to the list of listeners. Each listener in the list
        /// will have its OnEventRaised method called when this GameEvent is 
        /// raised.
        /// </summary>
        /// <param name="listener">The listener to add to this GameEvent's list 
        /// of listeners.</param>
        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        /// <summary>
        /// Removes a listener to the list of listeners, if the passed listener
        /// exists in the list.
        /// </summary>
        /// <param name="listener">The listener to remove from this GameEvent's 
        /// list of listeners.</param>
        public void UnregisterListener(GameEventListener listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}
