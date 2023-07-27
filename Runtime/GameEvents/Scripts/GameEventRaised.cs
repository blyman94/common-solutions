/*
File: GameEventRaised.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.26.2023

Description:
This script contains a delegate to be used by the GameEvent system. It is used 
to signal that the GameEvent has been raised, such that scripts may listen for
this event without being set up in the inspector.

Changelog:
V1.0 - Initial Documentation (7.26.2023)
*/

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Delegate to signal that a game event has been raised.
    /// </summary>
    public delegate void GameEventRaised();
}
