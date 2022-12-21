using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform; // reference to the player's transform
    public GameManager gameManager;
    public float followDistance = 5.0f; // maximum distance at which the enemy will start following the player
    public float followSpeed = 5.0f; // speed at which the enemy will follow the player

    private void FixedUpdate()
    {
        if (gameManager.timescale != 0)
        {
            // check if the distance between the enemy and the player is less than the follow distance
            if (Vector3.Distance(transform.position, playerTransform.position) < followDistance)
            {
                // if the distance is less than the follow distance, move towards the player
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);
            }
        }
    }
}