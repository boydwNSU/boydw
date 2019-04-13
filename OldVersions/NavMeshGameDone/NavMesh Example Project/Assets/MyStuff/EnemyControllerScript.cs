using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyControllerScript : MonoBehaviour
{
    #region Attributes
    private Animator animator;
    

    private const string RUN_ANIMATION_BOOL = "Run";
    private const string ATTACKBITE_ANIMATION_BOOL = "AttackBite";
    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string TAIL_WHIP_ANIMATION_BOOL = "TailWhip";
    private const string PLAYER_HEALTH = "PlayerHealth";

    #endregion

    private int playerHealth = 3;

    public UnityEngine.AI.NavMeshAgent enemyAgent;
    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        Animate(RUN_ANIMATION_BOOL);

        //enemyAgent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.transform.position);
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Collided with " + other.name);
            Animate(ATTACKBITE_ANIMATION_BOOL);
            enemyAgent.isStopped = true;
            playerHealth--;
        }
        
    }
    

    private void OnTriggerExit(Collider other)
    {
        Animate(RUN_ANIMATION_BOOL);
        enemyAgent.isStopped = false;
    }

    private IEnumerator AnimateIdle(string intName)
    {
        yield return new WaitForSeconds(1F);

        DisableOtherAnimations(animator, intName);
        Debug.Log("Int is " + playerHealth);

        animator.SetInteger(intName, playerHealth);

    }

    private IEnumerator AnimateTail(string boolName)
    {
        yield return new WaitForSeconds(1f);

        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);

    }

    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);

    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}
