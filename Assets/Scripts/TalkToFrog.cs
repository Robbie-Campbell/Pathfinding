using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToFrog : MonoBehaviour
{
    public GameObject dialogManager;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            dialogManager.SetActive(true);
            Time.timeScale = 0.001f;
        }
    }
}
