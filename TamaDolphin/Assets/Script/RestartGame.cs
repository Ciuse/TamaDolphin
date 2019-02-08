using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PointerEnterRestart()
    {
        StartCoroutine("RestartGameFunction");
    }
    public void PointerExitNotRestart()
    {
        StopCoroutine("RestartGameFunction");
    }

    private IEnumerator RestartGameFunction()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("StartGame");

    }
}
