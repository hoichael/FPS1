using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    public string nextLevel;

    public float loadDelay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(nextLevel);
    }
}
