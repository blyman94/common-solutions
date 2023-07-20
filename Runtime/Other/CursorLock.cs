/*
File: CursorLock.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.20.2023

Description:
This script allows the user to easily lock and unlock the game's cursor. A
locked cursor is invisible and snaps to the middle of the screen. In the editor,
the user can press "esc" to see their cursor again. An unlocked cursor can 
move around the screen freely. 

Changelog:
V1.0 - Initial Documentation (7.20.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Allows the user to easily lock and unlock the game's cursor.
    /// </summary>
    public class CursorLock : MonoBehaviour
    {
        /// <summary>
        /// Should the cursor be locked at the start of the scene?
        /// </summary>
        [Tooltip("Should the cursor be locked at the start of the scene?")]
        [SerializeField] private bool _lockCursorOnStart;

        #region MonoBehaviour Methods
        private void Start()
        {
            if (_lockCursorOnStart)
            {
                LockCursor();
            }
            else
            {
                UnlockCursor();
            }
        }
        #endregion

        /// <summary>
        /// Locks the cursor to the center of the screen and hides it.
        /// </summary>
        public void LockCursor()
        {
            LockCursor(false);
        }

        /// <summary>
        /// Locks the cursor to the center of the screen. Parameter allows the
        /// cursor to remain visible or to hide it.
        /// </summary>
        /// <param name="isVisible">Should the cursor be visible when it is
        /// locked to the center of the screen?</param>
        public void LockCursor(bool isVisible)
        {
            Cursor.visible = isVisible;
            Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Unlocks the cursor and shows it.
        /// </summary>
        public void UnlockCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
