/*
File: DebugLogger.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.21.2023

Description:
This script makes the Debug.Log(string message) and 
Debug.LogWarning(string message) methods accessible from the inspector. Works 
well with the GameEvent system.

Changelog:
V1.0 - Initial Documentation (7.21.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Makes the Debug.Log(string message) and Debug.LogWarning(string message) 
    /// methods accessible from the inspector.
    /// </summary>
    public class DebugLogger : MonoBehaviour
    {
        /// <summary>
        /// A method that makes the Debug.Log(string message) functionality 
        /// accessible from the inspector.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Log(string message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// A method that makes the Debug.LogWarning(string message) 
        /// functionality accessible from the inspector.
        /// </summary>
        /// <param name="message">Warning message to be logged.</param>
        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }
    }
}

