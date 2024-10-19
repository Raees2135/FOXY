using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private AudioSource hurtSound;

    [SerializeField] private AudioSource dieSound;

    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        health = 3;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hearts = GameObject.FindGameObjectWithTag("Heart").GetComponentsInChildren<Image>();
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void Update()
    {
        Health();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Hit");
            animator.SetTrigger("hurt");
            health--;
            if(health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        rb.velocity = new Vector2(rb.velocity.x, 14f);
        hurtSound.Play();
        Physics2D.IgnoreLayerCollision(7, 8);
        animator.SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        animator.SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void Die()
    {
        dieSound.Play();
        animator.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void Health()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
