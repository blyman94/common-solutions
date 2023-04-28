/*
File: FadeFinished.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.28.2023

Description:
This script contains a delegate to be used by the Fader abstract class to signal 
that the class extending Fader has finished with a fading process.

Changelog:
V1.0 - Initial Documentation (4.28.2023)
*/

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Delegate to signal that a Fader has finished fading.
    /// </summary>
    public delegate void FadeFinished();
}
