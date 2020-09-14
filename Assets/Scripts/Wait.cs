using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    public float wait_time = 16f;
    public int SceneToLoad;

    void Start()
    {
        StartCoroutine(WaitIntro());
    }

    IEnumerator WaitIntro()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene(SceneToLoad);
    } 

}
