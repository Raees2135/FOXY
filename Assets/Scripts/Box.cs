using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            StartCoroutine(BoxDisapear());
        }
    }

    IEnumerator BoxDisapear()
    {
        animator.SetBool("vibrate", true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }


}
