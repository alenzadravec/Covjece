using UnityEngine;
using UnityEngine.Events;

public class SetScriptableReference : MonoBehaviour
{
    public UnityEvent _setScriptableReferenceStateEvent;

    private void OnEnable()
    {
        _setScriptableReferenceStateEvent.Invoke();
    }
}
