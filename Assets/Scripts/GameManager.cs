using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public bool levelEnding;

    private void Awake()
    {
        instance = this;
    }
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        StartCoroutine(PlayerRespawn());
    }

    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(5f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
