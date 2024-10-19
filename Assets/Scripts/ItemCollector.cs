using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private Text cheriiesText;

    [SerializeField] private AudioSource collectSound;

    private void Start()
    {
        cheriiesText = GameObject.Find("CherriesText").GetComponent<Text>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            cherries++;
            cheriiesText.text = "Cherries : " + cherries;
        }
    }
}
