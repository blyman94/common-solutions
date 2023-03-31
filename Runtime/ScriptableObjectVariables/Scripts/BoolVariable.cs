/*
File: BoolVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the BoolVariable class, which extends 
ScriptableObjectVariable and allows the user to store a boolean at the asset
level.

To create a BoolVariable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Bool" from the resulting submenu.
4. Name your new BoolVariable something descriptive (i.e., PlayerHasKeyBool)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the boolean data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Bool",
        fileName = "New Bool Variable")]
    public class BoolVariable : ScriptableObjectVariable<bool>
    {

    }
}
