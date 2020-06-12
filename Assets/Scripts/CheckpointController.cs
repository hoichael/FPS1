using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour
{

    public string checkpointName;
    
    
    void Start()
    {
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_checkpoint"))
        {
            if(PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_checkpoint") == checkpointName)
            {
                PlayerController.instance.transform.position = transform.position;
            }
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_checkpoint", checkpointName);
            Debug.Log("hit " + checkpointName);
        }
    }
}
