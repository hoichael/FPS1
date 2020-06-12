using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Vector3 _thrust;
    [SerializeField]
    private float _force = 4f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        /*  transform.eulerAngles = new Vector3(
          transform.eulerAngles.x,
          transform.eulerAngles.y + 180,
          transform.eulerAngles.z);
        */


        //  transform.localRotation = Quaternion.Euler(0, 90, 90);


        //  _rb.AddForce(_thrust, ForceMode.Impulse);

        _rb.AddForce(transform.right * _force, ForceMode.Impulse);
        _rb.AddForce(transform.forward * _force, ForceMode.Impulse);
        _rb.AddTorque(transform.forward * _force/2, ForceMode.Impulse);

        StartCoroutine(Despawn());
    }

   IEnumerator Despawn()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
    
}
