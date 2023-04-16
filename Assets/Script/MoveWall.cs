using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float moveWallSpeed;

    private void Update()
    {
        transform.position += Vector3.left * moveWallSpeed * Time.deltaTime;
    }
}
