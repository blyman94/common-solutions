/*
File: ValueUpdated.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains a delegate to be used by the ScriptableObjectVariable 
system. It is used to signal that the value of a ScriptableObjectVariable has 
been updated, such that any observer can be notified of the change. It can also
be used as a very general delegate in other use cases.

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Delegate to signal that a value has been updated.
    /// </summary>
    public delegate void ValueUpdated();
}
