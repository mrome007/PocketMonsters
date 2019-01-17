using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterEncounterCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Collider2D playerCollider;
    private float encounterTimer = 0f;
    private float maximumEncounterTime = 12f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var encounter = collision.gameObject.GetComponent<MonsterEncounter>();
        if(encounter != null)
        {
            encounterTimer = Random.Range(0f, maximumEncounterTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var encounter = collision.gameObject.GetComponent<MonsterEncounter>();
        if(encounter != null)
        {
            encounterTimer -= Time.deltaTime;
            if(encounterTimer < 0f)
            {
                //TODO: Stop movement somehow and disable collider.
                Debug.Log("LOAD BATTLE SEQUENCE HERE!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var encounter = collision.gameObject.GetComponent<MonsterEncounter>();
        if(encounter != null)
        {
            encounterTimer = 0f;
        }
    }
}
