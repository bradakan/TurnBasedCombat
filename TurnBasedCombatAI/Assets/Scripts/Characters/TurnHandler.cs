using UnityEngine;
using System.Collections;

public class TurnHandler : MonoBehaviour
{


    public float cooldownBetweenTurns;
    float lastTimeRecordedForCooldown;
    public bool playerTurn = true;
    public GameObject playerUI;
    // Update is called once per frame
    void Update()
    {
        if (playerTurn == false)
        {
            if (lastTimeRecordedForCooldown + cooldownBetweenTurns <= Time.time)
            {
                //enemyAttack
                GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterBehavior>().Attack();
            }
        }
        else if (playerTurn == true)
        {
            if (lastTimeRecordedForCooldown + cooldownBetweenTurns <= Time.time)
            {
                playerUI.SetActive(true);
                //PlayerAttack
                //show menu with attack button
            }
        }
        }

    public void SwitchTurn()
    {
        if (playerTurn == true)
        {
            playerTurn = false;
            playerUI.SetActive(false);
        }
        else
        {
            playerTurn = true;
        }

        lastTimeRecordedForCooldown = Time.time;
    }

}
