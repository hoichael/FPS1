using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField]
    private float swayAmount;
    [SerializeField]
    private float smoothAmount;
    [SerializeField]
    private float maxAmount;
    private Vector3 _initialPosition;
    
    void Start()
    {
        _initialPosition = transform.localPosition;
    }

    void Update()
    {
        float swayX = -Input.GetAxis("Mouse X") * swayAmount;
        float swayY = -Input.GetAxis("Mouse Y") * swayAmount;
        swayX = Mathf.Clamp(swayX, -maxAmount, maxAmount);
        swayY = Mathf.Clamp(swayY, -maxAmount, maxAmount);

        Vector3 targetPosition = new Vector3(swayX, swayY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition + _initialPosition, Time.deltaTime * smoothAmount);
    }
}
