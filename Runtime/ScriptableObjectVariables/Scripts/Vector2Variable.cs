/*
File: Vector2Variable.cs
Author: Brandon Lyman (blyman94)
Creation Date: 3.31.2023

Description:
This script contains the Vector2Variable class, which extends 
ScriptableObjectVariable and allows the user to store a Vector2 at the asset
level.

To create a Vector2Variable asset:

1. Open the Unity Editor
2. Right click in the Project window
3. At the top of the resulting menu, select "ScriptableObjectVariable," then
"Vector2" from the resulting submenu.
4. Name your new Vector2Variable something descriptive 
(i.e., PlayerPositionVector2)

Changelog:
V1.0 - Initial Documentation (3.31.2023)
*/

using UnityEngine;

namespace Blyman94.CommonSolutions
{
    /// <summary>
    /// An asset level representation of the Vector2 data type.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjectVariable/Vector2",
        fileName = "New Vector2 Variable")]
    public class Vector2Variable : ScriptableObjectVariable<Vector2>
    {

    }
}
