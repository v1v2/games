using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainsLayer : MonoBehaviour
{
    private float moveSpeed = 1f;
    private Vector2 startPosition;
    private float offset;
    private float newXPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        newXPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPosition + Vector2.right * newXPosition;
    }
}
