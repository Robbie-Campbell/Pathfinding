using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CheckForDeath : MonoBehaviour
{
    GameObject player;
    public GameObject Death;

    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
        }
    }
}
