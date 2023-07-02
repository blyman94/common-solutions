/*
File: Packages.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.2.2023

Description:
This static class contains methods that are used to edit the package manifest
of a Unity project. This script is adapted from Jason Storey's methods. For more 
information, please visit his YouTube channel 
(https://www.youtube.com/@JasonStorey).

Changelog:
V1.0 - Initial Documentation (7.2.2023)
*/

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// A static class that contains methods useful for editing a project's
    /// package manifest.
    /// </summary>
    public static class Packages
    {
        /// <summary>
        /// Constructs a Url out of a Github Gist id and a GitHub user name.
        /// </summary>
        /// <param name="id">Id of the Github Gist from which the manifest will 
        /// be loaded.</param>
        /// <param name="user">Username of the Github Gist host.</param>
        /// <returns>String representing the Url from which the manifest will be
        /// downloaded.</returns>
        public static string GetGistUrl(string id, string user = "blyman94")
        {
            return string.Format("https://gist.githubusercontent.com/{0}/{1}/raw", user, id);
        }

        /// <summary>
        /// Retrieves the package manifest content from the specified Url.
        /// </summary>
        /// <param name="url">Url from which the manifest contents will be 
        /// downloaded.</param>
        /// <returns>String representing the contents of the online package 
        /// manifest.</returns>
        public static async Task<string> GetPackageManifestContents(string url)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        /// <summary>
        /// Replaces the existing package manifest file with the passed 
        /// contents.
        /// </summary>
        /// <param name="contents">The contents with which the existing package 
        /// manifest will be replaced.</param>
        public static void ReplacePackageFile(string contents)
        {
            string existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }
    }
}
