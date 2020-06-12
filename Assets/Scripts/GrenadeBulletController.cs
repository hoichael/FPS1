using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBulletController : MonoBehaviour
{
  //  [SerializeField]
  //  private float _moveSpeed;
    [SerializeField]
    private Rigidbody _rb;
  //  [SerializeField]
  //  private GameObject _impactEffect;
  //  [SerializeField]
  //  private GameObject _impactEnemyEffect;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _force;
    [SerializeField]
    private float _upForce;
    [SerializeField]
    private float _torque;
    [SerializeField]
    private GameObject _grenadeExplosion;



    void Start()
    {
        _rb.AddForce(transform.forward * _force);
        _rb.AddForce(transform.up * _upForce);
        _rb.AddTorque(transform.forward * _torque, ForceMode.Impulse);
        StartCoroutine(Explode());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {            
            Instantiate(_grenadeExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(4);
        Instantiate(_grenadeExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}