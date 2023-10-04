using UnityEngine;
using UnityEngine.Events;

namespace Blyman94.CommonSolutions
{
    public class InvokeUnityEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _eventToInvoke;

        public void Execute()
        {
            _eventToInvoke?.Invoke();
        }
    }
}
