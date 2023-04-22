using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            GameManager.instance.AddScore();
            Destroy(collision.gameObject, 0.02f);
        }

        if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
