using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerJumper : MonoBehaviour
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
    private Vector3 _jumpDir;

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
    [SerializeField]
    private float _force;

    // private Vector3 _moveDestination;
    // [SerializeField]
    // private float _timerMoveDestination = 10f;
    // private float _setTimerMoveDestination = 10f;


    void Start()
    {
        _shootTimeCounter = _timeToShoot;
        _shotWaitCounter = _waitBetweenShooting;
        //  StartCoroutine(SetNewDestination());
    }

    /*  IEnumerator SetNewDestination()
       {
           _moveDestination = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
           yield return new WaitForSeconds(1);
      } */


    void Update()
    {

        /*  _timerMoveDestination--;
          if (_timerMoveDestination < 0)
          {
              SetNewDestination();
          } */

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
            else
            {
                transform.LookAt(_targetPoint);

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

                        if (_fireCount <= 0)
                        {
                            _fireCount = _fireRate;

                            Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
                        }


                    }
                    else
                    {
                        _rb.constraints = RigidbodyConstraints.None;
                        _rb.useGravity = true;
                        _shotWaitCounter = _waitBetweenShooting;
                        _jumpDir = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
                        _rb.AddForce(_jumpDir * _force);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Solid")
        {
            _rb.useGravity = false;
            _rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            Debug.Log("arrrrg");
        }
    }
}
