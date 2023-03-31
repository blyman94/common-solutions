/*
File: IntVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the IntVariable class, which extends 
ScriptableObjectVariable and allows the user to store an integer at the asset
level.

To create an IntVariable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Int" from the resulting submenu.
4. Name your new IntVariable something descriptive (i.e., PlayerHealthInt)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the integer data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Int",
        fileName = "New Int Variable")]
    public class IntVariable : ScriptableObjectVariable<int>
    {

    }
}
