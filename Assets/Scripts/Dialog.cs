using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.00001f;

    public GameObject continueButton;
    public GameObject DestroyableNPC;
    public GameObject enemySpawner;
    public Animator animator;
    public AudioSource audio;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
       foreach(char letter in sentences[index].ToCharArray())
        {
            audio.Play();
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        animator.SetTrigger("Change");
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index += 1;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            Time.timeScale = 1;
            Destroy(DestroyableNPC);
            enemySpawner.SetActive(true);
        }
    }
}
