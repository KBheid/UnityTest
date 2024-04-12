using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAtValue : MonoBehaviour
{
    [SerializeField] int valueToTrigger = 10;

    [SerializeField] UnityEvent OnValueReached;

    private int _currentValue = 0;

    public void IncrementValue()
    {
		_currentValue++;
        if (_currentValue >= valueToTrigger)
            OnValueReached?.Invoke();
    }
}
