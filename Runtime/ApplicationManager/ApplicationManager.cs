/*
File: ApplicationManager.cs
Author: Brandon Lyman (blyman94)
Creation Date: 4.6.2023

Description:
This script allows the user to create an AssetManager scriptable object that can
control scene and application logic from the asset level. The power of this
method is that methods from the ApplicationManager can be called from any scene.
For GameObjects, it's functions can be called through a serialized reference to 
the ApplicationManager class. For UI elements such as buttons, the
ApplicationManager ScriptableObject instance can be dragged into UnityEvents
such as OnClick() to allow direct access to these methods.

Changelog:
V1.0 - Initial Documentation (4.6.2023)
*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// Class that allows for easy access of Unity's built-in SceneManager, as 
    /// well as shutting down the application. There only needs to be one 
    /// instance of the ApplicationManager in the project.
    /// </summary>
    [CreateAssetMenu]
    public class ApplicationManager : ScriptableObject
    {
        /// <summary>
        /// WARNING: Do not use this method unless you have a use case for it. 
        /// Most of the time you will want to use the LoadSceneSingle methods. 
        /// Loads a scene on top of the existing scene based on it's index 
        /// number in the build settings. Please note, a scene must be added to 
        /// the build settings to be accessible by this method. In that UI it 
        /// will be assigned an index number that can be specified as an 
        /// argument here. 
        /// </summary>
        /// <param name="sceneIndex">Index of the scene to be loaded.</param>
        public void LoadSceneAdditive(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        }

        /// <summary>
        /// WARNING: Do not use this method unless you have a use case for it. 
        /// Most of the time you will want to use the LoadSceneSingle methods. 
        /// Overload. Loads a scene on top of the existing scene based on it's 
        /// name as a string. Please note, a scene must be added to the build 
        /// settings to be accessible by this method.
        /// </summary>
        /// <param name="sceneName">Name of the scene to be loaded.</param>
        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        /// <summary>
        /// Unloads the current scene and loads a scene based on it's index 
        /// number in the build settings. Please note, a scene must be added to 
        /// the build settings to be accessible by this method. In that UI it 
        /// will be assigned an index number that can be specified as an 
        /// argument here.
        /// </summary>
        /// <param name="sceneIndex">Index of the scene to be loaded.</param>
        public void LoadSceneSingle(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }

        /// <summary>
        /// Overload. Unloads the current scene and loads a scene based on it's
        /// name as a string. Please note, a scene must be added to the build 
        /// settings to be accessible by this method.
        /// </summary>
        /// <param name="sceneName">Name of the scene to be loaded.</param>
        public void LoadSceneSingle(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        /// <summary>
        /// Quits the application. Does not work for WebGL.
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Reloads the current active scene. Keep in mind all scene-level state 
        /// will be lost (and all asset-level data will persist). Ensure that 
        /// this is considered in startup functions for this method to work as 
        /// intended.
        /// </summary>
        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,
                LoadSceneMode.Single);
        }

        /// <summary>
        /// Restarts the application by unloading the current scene and loading 
        /// the first scene from the build settings.
        /// </summary>
        public void Restart()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
