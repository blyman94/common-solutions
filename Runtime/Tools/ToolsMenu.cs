/*
File: ToolsMenu.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.2.2023

Description:
This static class contains methods that are accessible from the Unity Editor, 
via a custom toolbar menu called "Tools". This script is adapted from Jason
Storey's methods. For more information, please visit his YouTube channel 
(https://www.youtube.com/@JasonStorey).

Changelog:
V1.0 - Initial Documentation (7.2.2023)
*/

using UnityEditor;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// A static class defining methods callable from the Unity Editor via a 
    /// custom "Tools" menu option.
    /// </summary>
    public static class ToolsMenu
    {
        /// <summary>
        /// Loads a new pacakge manifest from the designated GitHub Gist id.
        /// </summary>
        [MenuItem("Tools/Setup/Load Custom Default Packages")]
        private static async void LoadNewManifest()
        {
            string url = Packages.GetGistUrl("0d9701f8fb532fff61e96612169bed84");
            string contents = await Packages.GetPackageManifestContents(url);
            Packages.ReplacePackageFile(contents);
        }
    }
}
