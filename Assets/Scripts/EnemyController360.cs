using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController360 : MonoBehaviour
{
    //   [SerializeField]
    //  private float _moveSpeed;
    //   [SerializeField]
    //   private Rigidbody _rb;
    private bool _chasing;
    [SerializeField]
    private float _chaseDistance = 30f;
    [SerializeField]
    private float _loseDistance = 40f;
    [SerializeField]
    private NavMeshAgent _agent;

    private Vector3 _targetPoint;

    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private float _waitBetweenShooting;
    [SerializeField]
    private float _timeToShoot = 1f;

    private float _fireCount;
    private float _shotWaitCounter;
    private float _shootTimeCounter;
    private Vector3 _lookPoint;


    void Start()
    {
        _shootTimeCounter = _timeToShoot;
        _shotWaitCounter = _waitBetweenShooting;
    }

    void Update()
    {
        if (!PlayerController.instance.gameObject.activeInHierarchy)
        {
            _targetPoint = transform.position;
            _agent.destination = _targetPoint;
        }

        if (PlayerController.instance.gameObject.activeInHierarchy)
        {

            _targetPoint = PlayerController.instance.transform.position;
            // _targetPoint.y = transform.position.y;
            _lookPoint = new Vector3(_targetPoint.x, _targetPoint.y + 1.2f, _targetPoint.z);


            if (!_chasing)
            {
                if (Vector3.Distance(transform.position, _targetPoint) < _chaseDistance)
                {
                    _chasing = true;
                    _shootTimeCounter = _timeToShoot;
                    _shotWaitCounter = _waitBetweenShooting;
                }

            }
            else
            {

                _firePoint.LookAt(_lookPoint);
                // transform.LookAt(_lookPoint);
                // transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.x);

                //   _rb.velocity = transform.forward * _moveSpeed;

                _agent.destination = _targetPoint;

                if (Vector3.Distance(transform.position, _targetPoint) > _loseDistance)
                {
                    _chasing = false;
                }

                if (_shotWaitCounter > 0)
                {
                    _shotWaitCounter -= Time.deltaTime;
                    if (_shotWaitCounter <= 0)
                    {
                        _shootTimeCounter = _timeToShoot;
                    }


                }
                else
                {

                    _shootTimeCounter -= Time.deltaTime;

                    if (_shootTimeCounter > 0)
                    {
                        _fireCount -= Time.deltaTime;

                        if (_fireCount <= 0)
                        {
                            _fireCount = _fireRate;

                            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                        }

                        _agent.destination = transform.position;
                    }
                    else
                    {
                        _shotWaitCounter = _waitBetweenShooting;
                    }
                }


            }
        }
    }
}