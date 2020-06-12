using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway1 : MonoBehaviour
{


    public float rotationAmount = 4;
    public float maxRotationAmount = 5f;
    public float smoothRotation = 12f;


    public bool rotationX = true;
    public bool rotationY = true;
    public bool rotationZ = true;
    
    [SerializeField]
    private float swayAmount;
    [SerializeField]
    private float smoothAmount;
    [SerializeField]
    private float maxAmount;
    
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private float InputX;
    private float InputY;


    void Start()
    {
        _initialPosition = transform.localPosition;
        _initialRotation = transform.localRotation;
    }

    void Update()
    {
        CalcSway();
        ApplySway();
        Tilt();
    }

    void CalcSway()
    {
         InputX = -Input.GetAxis("Mouse X") * swayAmount;
         InputY = -Input.GetAxis("Mouse Y") * swayAmount;
    }

    private void ApplySway()
    {
       float swayX = Mathf.Clamp(InputX, -maxAmount, maxAmount);
       float swayY = Mathf.Clamp(InputY, -maxAmount, maxAmount);

        Vector3 targetPosition = new Vector3(swayX, swayY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition + _initialPosition, Time.deltaTime * smoothAmount);
    }

    private void Tilt()
    {
       float tiltY = Mathf.Clamp(InputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
       float tiltX = Mathf.Clamp(InputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

        Quaternion targetRotation = Quaternion.Euler(new Vector3(rotationX ? -tiltX : 0f, rotationY ? tiltY : 0f, rotationZ ? tiltY : 0));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation * _initialRotation, Time.deltaTime * smoothRotation);
    }
}
