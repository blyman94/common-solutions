/*
File: ScriptableObjectVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains a generic, abstract class called ScriptableObjectVariable.
A ScriptableObjectVariable is an asset-level representation of a piece of data.
Moving data that many different GameObjects within a scene depends on helps to
decouple systems, improving the ability to debug such systems or test them in 
isolation.

Note that the value of a ScriptableObjectVariable does not automatically reset
when the application shuts down. This is both a bane and a boon of the
Event-Based ScriptableObject Architecture (EBSOA). Be careful to reset the 
values of a ScriptableObjectVariable when appropriate. For example, you may want 
to set the PlayerHealth IntVariable's value to 3 in the Player.cs class's 
Awake() method.

To extend this class for whatever data type is needed, simply create a new class 
that inherits from ScriptableObjectVariable and insert the desired data type
into the generic class head. See IntVariable.cs for an example.

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Variable stored at the asset level. Invokes a delegate when the value is 
    /// updated.
    /// </summary>
    /// <typeparam name="T">Type of variable to be stored.</typeparam>
    public abstract class ScriptableObjectVariable<T> : ScriptableObject
    {
        /// <summary>
        /// Delegate to signal that this ScriptableObjectVariable has been 
        /// updated.
        /// </summary>
        public ValueUpdated ValueUpdated;

        /// <summary>
        /// The value of this variable as a <T>.
        /// </summary>
        [SerializeField] protected T value;

        /// <summary>
        /// The value of this variable as a <T>. Invokes ValueUpdated when set.
        /// </summary>
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                ValueUpdated?.Invoke();
            }
        }
    }
}
