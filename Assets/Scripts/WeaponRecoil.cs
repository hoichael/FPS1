using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField]
    private float recoilAmount;
    public float smoothAmount;    
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;

    void Start()
    {
        _initialPosition = transform.localPosition;       
    }

    void Update()
    {        
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition + _initialPosition, Time.deltaTime * smoothAmount);
    }

    public void Recoil()
    {
        Vector3 _targetPosition = new Vector3(0, 0f, transform.localPosition.z - recoilAmount);
        transform.localPosition = _targetPosition;
    }
}
