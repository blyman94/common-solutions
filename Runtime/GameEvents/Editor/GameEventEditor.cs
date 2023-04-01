/*
File: GameEventEditor.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.1.2023

Description:
This script describes a custom editor for the GameEvent class that allows the
user to raise the event manually from the inspector. This is especially helpful
in testing and debugging within the Event-Based ScriptableObject Architecture
(EBSOA).

Changelog:
V1.0 - Initial Documentation (4.1.2023)
*/

using UnityEngine;
using UnityEditor;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Custom editor for the GameEvent class that allows the user to manually
    /// raise the GameEvent from the inspector while the application is running.
    /// </summary>
    [CustomEditor(typeof(GameEvent))]
    [CanEditMultipleObjects]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GameEvent gameEvent = target as GameEvent;

            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.ObjectField("Script",
                MonoScript.FromScriptableObject((ScriptableObject)target),
                GetType(), false);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Testing", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Use this button to manually raise " + 
            "this event while in Play Mode.");
            
            if (GUILayout.Button("Raise"))
            {
                if (Application.isPlaying)
                {
                    gameEvent.Raise();
                }
            }
        }
    }
}
