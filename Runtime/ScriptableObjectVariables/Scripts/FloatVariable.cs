/*
File: FloatVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the FloatVariable class, which extends 
ScriptableObjectVariable and allows the user to store a float at the asset 
level.

To create a FloatVariable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Float" from the resulting submenu.
4. Name your new FloatVariable something descriptive (i.e., PlayerHealthFloat)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the float data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Float",
        fileName = "New Float Variable")]
    public class FloatVariable : ScriptableObjectVariable<float>
    {

    }
}