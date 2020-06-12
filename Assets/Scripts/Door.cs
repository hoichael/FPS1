using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Transform doorModel;
    public GameObject collision;
    public float openSpeed;
    private bool _shouldOpen;
    private Vector3 _initPosition;
    private Vector3 _targetPosition;


    void Start()
    {
        _initPosition = doorModel.transform.position;
        _targetPosition = new Vector3(_initPosition.x, _initPosition.y - 4f, _initPosition.z);
    }

    
    void Update()
    {
       if (_shouldOpen && doorModel.position != _targetPosition)
       {
            doorModel.position = Vector3.MoveTowards(doorModel.position, _targetPosition, openSpeed * Time.deltaTime);
            if (doorModel.position == _targetPosition)
            {
                Debug.Log("asdfdf");
                collision.SetActive(false);
            }
       }
       else if (!_shouldOpen && doorModel.position != _initPosition)
        {
            
            doorModel.position = Vector3.MoveTowards(doorModel.position, _initPosition, openSpeed * Time.deltaTime);

            if (doorModel.position == _initPosition)
            {
                collision.SetActive(true);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("lsadnf");
            _shouldOpen = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _shouldOpen = false;
        }
    }
}
