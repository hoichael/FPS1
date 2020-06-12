using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBig3S : MonoBehaviour
{
    private bool _chasing;
    [SerializeField]
    private float _chaseDistance = 30f;
    [SerializeField]
    private float _loseDistance = 40f;
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent _agent;

    private Vector3 _targetPoint;

    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private Transform _firePoint2;
    [SerializeField]
    private Transform _firePoint3;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private float _waitBetweenShooting;
    [SerializeField]
    private float _timeToShoot = 1f;

    private float _fireCount;
    private float _shotWaitCounter;
    private float _shootTimeCounter;


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
                // transform.LookAt(_targetPoint);

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

                            _firePoint.LookAt(_targetPoint + new Vector3(0f, 1.2f, 0f));

                            //check angle to player
                            Vector3 _targetDir = _targetPoint - transform.position;
                            float _angle = Vector3.SignedAngle(_targetDir, transform.forward, Vector3.up);

                            if (Mathf.Abs(_angle) < 66)
                            {
                                Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                                Instantiate(_bullet, _firePoint2.position, _firePoint.rotation);
                                Instantiate(_bullet, _firePoint3.position, _firePoint.rotation);
                            }
                            else
                            {
                                _shotWaitCounter = _waitBetweenShooting;
                            }

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
