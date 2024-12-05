using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Queue<Vector3> positionHistory = new Queue<Vector3>(); // Save old position
    [SerializeField] private float historyInterval = 0.1f; // Time between each save
    [SerializeField] private float respawnDelay = 2f; // Time rewinds before hitting the trap
    private Transform player; // Respawn player
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform; 
    }
    
    void Update()
    {
        if (Time.frameCount % (int)(historyInterval / Time.deltaTime) == 0)
        {
            positionHistory.Enqueue(player.position);

            // Limited position to prevent memory
            if (positionHistory.Count > (int)(respawnDelay / historyInterval))
            {
                positionHistory.Dequeue();
            }
        }
    }

    public void RespawnPlayer()
    {
        player.position = positionHistory.Dequeue();
    }
    
}
