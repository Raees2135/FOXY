using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource finishSound;

    private bool levelCompleted = false;

    public int index;
    public string name;
    public int achieved;


    void Start()
    {
        finishSound = GetComponent<AudioSource>();

        achieved = PlayerPrefs.GetInt(name);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;

            if(achieved == 0)
            {
                index++;
                achieved++;
                PlayerPrefs.SetInt("highestLevel", index);
                PlayerPrefs.SetInt(name, achieved);
                PlayerPrefs.Save();
                Invoke("CompleteLevel", 2f);
            }

            if(achieved == 1)
            {
                Invoke("CompleteLevel", 2f);
            }
            
            
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("LevelSelection");
        
    }
}
