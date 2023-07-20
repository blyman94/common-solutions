/*
File: FpsLock.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.20.2023

Description:
This script allows the user to lock the FPS of their application based on target
platform. If the target platform is desktop, QualitySettings.VsyncCount should 
be used to control lock framerate. Otherwise, Application.targetFrameRate 
should be used to lock framerate. 

For more information, visit:
https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html 
https://docs.unity3d.com/ScriptReference/QualitySettings-vSyncCount.html

Changelog:
V1.0 - Initial Documentation (7.20.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// A class that locks the FPS of the game at a specified rate on awake. 
    /// This helps with stability and helps to mitigate fps spikes and dips.
    /// This class's awake function only needs to be executed once for the
    /// lifetime of the application, so it's best to put it in a boot scene or
    /// something similar.
    /// </summary>
    public class FpsLock : MonoBehaviour
    {
        /// <summary>
        /// Should framerate be locked on awake?
        /// </summary>
        [Tooltip("Should framerate be locked on awake?")]
        [SerializeField] private bool _lockFrameRate = true;

        /// <summary>
        /// Will this application be built to desktop?
        /// </summary>
        [Tooltip("Will this application be built to desktop?")]
        [SerializeField] private bool _isDesktopBuild = true;

        /// <summary>
        /// What is the target framerate? Note: Only applicable on non-desktop 
        /// builds.
        /// </summary>
        [Tooltip("What is the target framerate? Note: Only applicable on " +
            "non-desktop builds and the editor.")]
        [SerializeField] private int _targetFrameRate = 60;

        /// <summary>
        /// How many screen refreshes are allowed to pass between frames? In 
        /// practice, the default refresh rate of the system is divided by this 
        /// number to calculate target frames per second. For example, if the 
        /// refresh rate of the target system is 60hz, and vSyncCount = 2, the 
        /// target framerate will be 30fps.Note: Only applicable on desktop 
        /// builds.
        /// </summary>
        [Tooltip("How many screen refreshes are allowed to pass between " +
        "frames? In practice, the default refresh rate of the system is " +
        "divided by this number to calculate target frames per second. " +
        "For example, if the refresh rate of the target system is 60hz, " +
        "and _vSyncCount = 2, the target framerate will be 30fps. Note: " +
        "Only applicable on desktop builds, does not affect the editor.")]
        [Range(1, 4)]
        [SerializeField] private int _vSyncCount = 1;

        #region MonoBehaviour Methods
        private void Awake()
        {
            if (_lockFrameRate)
            {
                Application.targetFrameRate = _targetFrameRate;
                if (_isDesktopBuild)
                {
                    // Application.targetFrameRate will be ignored.
                    QualitySettings.vSyncCount = _vSyncCount;
                }
            }
            else
            {
                Application.targetFrameRate = -1;
                QualitySettings.vSyncCount = 0;
            }
        }
        #endregion
    }
}
