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

    #endregion



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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Animate(RUN_ANIMATION_BOOL);
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
