using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public DinoState DinoState;
    public List<BoxCollider2D> Dino_RunAndJumpCollinder;
    public BoxCollider2D Dino_DuckCollinder;

    public float moveSpeed;
    public bool IsGrounded { get; set; } = true;
    public bool CanMoveHorizontal { get; set; } = false;

    public Rigidbody2D rb;
    public Animator DinoAnimator;
    public float jumpForce = 15f;

    public AudioSource JumpSound;
    public AudioSource DeadSound;

    public GameObject DeadDino;
    public ParticleSystem JumpParticle;
    public ParticleSystem RunParticle;
    public void ChangeState(DinoState state)
    {
        DinoState = state;
        DinoState.SetDino(this);
        //Debug.Log(DinoState.GetType());
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
      
        CheckIsGrounded();
        if (IsGrounded)
        {
            RunParticle.Play();
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                 Jump();
            }
            else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.DownArrow))
            {          
                 ChangeState(new DuckState());
            }
            else
            {
                 ChangeState(new IdleState());
            }
           
        }
        else
        {
            
            ChangeState(new JumpState());
        }
        DinoState.ControllMovement();

        if(CanMoveHorizontal)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);                         
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void CheckIsGrounded()
    {
        // Check if the character is grounded
        if (gameObject.transform.position.y <= -0.3)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
       
    }
    void Jump()
    {
        JumpParticle.Play();
        JumpSound.Play();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
