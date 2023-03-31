/*
File: Vector3Variable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the Vector3Variable class, which extends 
ScriptableObjectVariable and allows the user to store a Vector3 at the asset
level.

To create a Vector3Variable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Vector3" from the resulting submenu.
4. Name your new Vector3Variable something descriptive 
(i.e., PlayerPositionVector3)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the Vector3 data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Vector3",
        fileName = "New Vector3 Variable")]
    public class Vector3Variable : ScriptableObjectVariable<Vector3>
    {

    }
}
