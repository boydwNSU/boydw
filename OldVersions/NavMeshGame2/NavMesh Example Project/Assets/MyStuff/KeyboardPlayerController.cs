using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class KeyboardPlayerController : MonoBehaviour
{
    public DeathAudio deathSound;
    public DamageAudio damageSound;
    public StatueAudio statueSound;
    public HealthBar playerHearts;

    #region Attributes
    private Animator animator;

    private const string RUN_ANIMATION_BOOL = "Run";
    private  string IDLE_ANIMATION_BOOL = "Idle";
    private const string WALK_ANMIATION_BOOL = "Walk";
    private const string DEATH_ANIMATION_BOOL = "Death";


    #endregion
    

    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = .1f;

    private int Health = 3;
    private int numOfStatues = 0;
    public GameObject statue1Dark;
    public GameObject statue2Dark;
    public GameObject statue3Dark;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;

    void Start()
    {
        animator = GetComponent<Animator>();
        //Animate(IDLE_ANIMATION_BOOL);
        
    }

    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
        playerHearts.health = Health;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Animate(RUN_ANIMATION_BOOL);
        }
        else if (Input.anyKey == false && Health > 0)
        {
            Animate(IDLE_ANIMATION_BOOL);
        }

        if(Health == 0)
        {
            moveSpeed = 0f;
            rotationRate = 0f;
            DisableOtherAnimations(animator, IDLE_ANIMATION_BOOL);
            Animate(DEATH_ANIMATION_BOOL);
            
        }

        if(Health == 0)
        {
            Invoke("GameOverPanel", 5f);
            Invoke("RestartGame", 10f);
        }

        if(numOfStatues == 3)
        {
            YouWinPanel();
            Invoke("RestartGame", 5f);
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
        if (other.tag == "Whale")
        {
            Health--;

            if (Health == 2 || Health == 1)
            {
                Debug.Log("Health is " + Health);
                damageSound.DamageSource.Play();
            }
            else if (Health == 0)
            {
                damageSound.DamageSource.Play();
                deathSound.DeathSource.PlayDelayed(.75f);
                DisableOtherAnimations(animator, IDLE_ANIMATION_BOOL);
                IDLE_ANIMATION_BOOL = "Wrong";
                
            }
        }

        if (other.tag == "Statue")
        {
            other.gameObject.SetActive(false);
            numOfStatues++;
            Debug.Log("Player has " + numOfStatues + " statues");
            statueSound.StatueSource.Play();

            if(numOfStatues == 1)
            {
                statue1Dark.gameObject.SetActive(false);
            }
            else if(numOfStatues == 2)
            {
                statue2Dark.gameObject.SetActive(false);
            }
            else if (numOfStatues == 3)
            {
                statue3Dark.gameObject.SetActive(false);
            }
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
 
    private void GameOverPanel()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    private void YouWinPanel()
    {
        youWinPanel.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
