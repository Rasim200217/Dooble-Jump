using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
   // public float moveWallSpeed;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
     {
         transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
     }
  
}
