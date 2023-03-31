/*
File: StringVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the StringVariable class, which extends 
ScriptableObjectVariable and allows the user to store a string at the asset
level.

To create a StringVariable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"String" from the resulting submenu.
4. Name your new StringVariable something descriptive (i.e., PlayerNameString)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the string data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/String",
        fileName = "New String Variable")]
    public class StringVariable : ScriptableObjectVariable<string>
    {

    }
}
