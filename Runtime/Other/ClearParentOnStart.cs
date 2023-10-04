using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blyman94.CommonSolutions
{
    public class ClearParentOnStart : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.SetParent(null);
        }
    }
}
