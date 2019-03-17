using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class KeyboardPlayerController : MonoBehaviour
{
    public DeathAudio deathSound;
    public DamageAudio damageSound;

    #region Attributes
    private Animator animator;


    private const string RUN_ANIMATION_BOOL = "Run";
    private const string DAMAGE_ANIMATION_BOOL = "TakeDamage";
    private const string IDLE_ANIMATION_BOOL = "Idle";
    private const string WALK_ANMIATION_BOOL = "Walk";
    private const string DEATH_ANIMATION_BOOL = "Death";


    #endregion


    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = .1f;

    private int Health = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        Animate(IDLE_ANIMATION_BOOL);
    }

    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Animate(RUN_ANIMATION_BOOL);
        }
        else
        {
            Animate(IDLE_ANIMATION_BOOL);
        }

        if(Health == 0)
        {
            Animate(DEATH_ANIMATION_BOOL);
        }
        
    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);

        
    }
    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
        
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * .0025f, 0);
    }

    #region AnimationFunctions

    private void OnTriggerEnter(Collider other)
    {
        
        Health--;
        Animate(DAMAGE_ANIMATION_BOOL);

        if(Health == 2 || Health == 1)
        {
            Debug.Log("Health is " + Health);
            damageSound.DamageSource.Play();
        }
        else if (Health == 0)
        {

            damageSound.DamageSource.Play();
            deathSound.DeathSource.PlayDelayed(.75f);
        }

        
        
    }
    

    private void AnimateWithoutDisable(string boolName)
    {
        animator.SetBool(boolName, true);
    }
    
    private void Animate(string boolName)
    {
        DisableOtherAnimations(animator, boolName);

        animator.SetBool(boolName, true);

    }

    private void DisableOtherAnimations(Animator animator, string animation)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name != animation)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
    #endregion
}
