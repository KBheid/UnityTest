using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] bool isRotating;
    [SerializeField] bool clockwise;

    [Range(1f, 360f)]
    [SerializeField] float rotationDegreesPerSecond;

	public void ToggleRotating() => isRotating = !isRotating;
	public void ToggleRotationDirection() => clockwise = !clockwise;


	void Update()
    {
        if (isRotating)
        {
            float rotationModifier = (clockwise) ? -1 : 1;
            transform.Rotate(new Vector3(0, 0, rotationDegreesPerSecond * rotationModifier * Time.deltaTime));
        }
    }

}
