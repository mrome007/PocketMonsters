using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonsterEncounterCollision : MonoBehaviour
{
    [SerializeField]
    private BattleSequence battleSequence;
    [SerializeField]
    private PocketMonstersStateManager stateManager;
    [SerializeField]
    private PocketMonsterParty playerParty;
    [SerializeField]
    private PocketMonsterParty enemyParty;

    private float encounterTimer = 0f;
    private float maximumEncounterTime = 12f;
    private Collider2D playerCollider;

    private void Awake()
    {
        playerCollider = GetComponent<Collider2D>();
        if(playerCollider == null)
        {
            Debug.LogError("No Collider");
            return;
        }
    }

    private void HandleBattleEnd(object sender, System.EventArgs e)
    {
        EndBattleSequence();   
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
                var monsterFromEncounter = encounter.GetMonsterFromEncounter();
                var monster = new LightMonster(HeavyMonsters.GetHeavyReference(monsterFromEncounter.x), (short)monsterFromEncounter.y);
                enemyParty.AddMonster(monster);
                StartBattleSequence();
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

    private void StartBattleSequence()
    {
        Debug.Log("Starting Battle Sequence.");
        battleSequence.BattleEnd += HandleBattleEnd;
        playerCollider.enabled = false;
        stateManager.ShowState(PocketMonsterState.BATTLE);
        battleSequence.StartBattleSequence(playerParty, enemyParty);
    }

    private void EndBattleSequence()
    {
        Debug.Log("Ending Battle Sequence.");
        battleSequence.BattleEnd -= HandleBattleEnd;
        playerCollider.enabled = true;
        stateManager.ShowState(PocketMonsterState.OVERWORLD);
    }
}
