/*
File: QuaternionVariable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 7.4.2023

Description:
This script contains the QuaternionVariable class, which extends 
ScriptableObjectVariable and allows the user to store a Quaternion at the asset
level.

To create a QuaternionVariable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Quaternion" from the resulting submenu.
4. Name your new QuaternionVariable something descriptive 
(i.e., PlayerRotationQuaternion)

Changelog:
V1.0 - Initial Documentation (7.4.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the Vector3 data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Quaternion",
        fileName = "New Quaternion Variable")]
    public class QuaternionVariable : ScriptableObjectVariable<Quaternion>
    {

    }
}
