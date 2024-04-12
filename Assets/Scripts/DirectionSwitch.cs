using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DirectionSwitch : MonoBehaviour
{
    static readonly float GIZMO_SIZE = 40f;

    [SerializeField] bool active = true;
    
    [SerializeField] Vector2 clickDirection;
    [Range(0.1f, 1f)]
    [SerializeField] float threshold;

    [SerializeField] float pauseDuration = 2.75f;


	[SerializeField] UnityEvent SwitchToggled;
	[SerializeField] UnityEvent BecameInactive;
	[SerializeField] UnityEvent BecameActive;

	private bool dragging = false;
    private Vector2 _clickPosition;

    // Ensure that clickDirection is normalized
	private void OnValidate() => clickDirection = clickDirection.normalized;

	public void OnSwitchPressed()
    {
        if (active)
        {
            _clickPosition = Input.mousePosition;
            dragging = true;
        }
    }

    public void OnSwitchReleased()
    {
        if (dragging && active)
        {
            Vector2 newMousePos = Input.mousePosition;
            Vector2 offset = newMousePos - _clickPosition;
            offset = offset.normalized;

            float sameness = Vector2.Dot(clickDirection, offset);

            if (sameness >= threshold)
            {
                StartCoroutine(nameof(PauseInteractivity), pauseDuration);
                SwitchToggled?.Invoke();
            }
        }
    }

	private IEnumerator PauseInteractivity(float duration)
	{
		BecameInactive?.Invoke();

		float elapsedTime = 0f;
		active = false;

		while (elapsedTime < duration)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		active = true;

		BecameActive?.Invoke();
	}

	#region Gizmo
	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;

        float thresholdAngleDegrees = 90 * threshold;

        Vector3 endPoint1 = Quaternion.AngleAxis(thresholdAngleDegrees, Vector3.forward) * (Vector3) clickDirection;
        Vector3 endPoint2 = Quaternion.AngleAxis(-thresholdAngleDegrees, Vector3.forward) * (Vector3) clickDirection;

		endPoint1 = endPoint1.normalized;
		endPoint2 = endPoint2.normalized;
		
        Gizmos.DrawRay(transform.position, endPoint1 * GIZMO_SIZE);
        Gizmos.DrawRay(transform.position, endPoint2 * GIZMO_SIZE);
	}
	#endregion
}
