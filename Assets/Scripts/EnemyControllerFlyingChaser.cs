using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerFlyingChaser : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private Rigidbody _rb;
    private bool _chasing;
    [SerializeField]
    private float _chaseDistance = 30f;
    [SerializeField]
    private float _loseDistance = 40f;
    [SerializeField]
   // private NavMeshAgent _agent;

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


    void Start()
    {
        _shootTimeCounter = _timeToShoot;
        _shotWaitCounter = _waitBetweenShooting;
    }

    void Update()
    {

        transform.LookAt(_targetPoint);

        if (!PlayerController.instance.gameObject.activeInHierarchy)
        {
            _targetPoint = transform.position;
            _rb.velocity = transform.forward * 0f;
        }
        
        if (PlayerController.instance.gameObject.activeInHierarchy)
        {

            _targetPoint = new Vector3(PlayerController.instance.transform.position.x, PlayerController.instance.transform.position.y + 1f, PlayerController.instance.transform.position.z);
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
            else if (Vector3.Distance(transform.position, _targetPoint) > 2f)
            {
               // transform.LookAt(_targetPoint);

                _rb.velocity = transform.forward * _moveSpeed;

                // _agent.destination = _targetPoint;

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

                        RaycastHit hit;
                        if ((_fireCount <= 0) && (Physics.Raycast(_firePoint.position, _firePoint.forward, out hit, 50f)) && (hit.transform.tag == "Player"))
                        {
                            _fireCount = _fireRate;

                            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                        }

                        // _agent.destination = transform.position;
                        _rb.velocity = transform.forward * 0f;
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
