using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly int VelocityHash = Animator.StringToHash("velocity");
    private const float AnimatorDampTime = 0.1f;
    private const string Grounded = "grounded";
    private InputReader inputReader;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Vector2 MovementParameter => Vector2.right * speed;
    private Vector2 JumpParameter => (MovementParameter / 2) + (Vector2.up * jumpForce);

    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        inputReader.JumpEvent += OnJump;
        inputReader.SlideEvent += OnSlide;
    }

    private void OnJump()
    {
        animator.SetBool(Grounded, false);
        rb.AddForce(JumpParameter, ForceMode2D.Impulse);
    }

    private void OnSlide()
    {
        animator.SetTrigger("slide");
    }

    void LateUpdate()
    {
        if (animator.GetBool(Grounded))
        {
            rb.velocity = MovementParameter;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BlendTreeJump"))
        {
            animator.SetFloat("velocity", Mathf.Clamp(rb.velocity.y, -1, 1));
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            boxCollider.enabled = false;
        }
        else if (!boxCollider.enabled)
        {
            boxCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !animator.GetBool(Grounded))
        {
            Debug.Log("OnCollisionEnter2D: Ground");
            animator.SetBool(Grounded, true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !animator.GetBool(Grounded))
        {
            Debug.Log("OnCollisionExit2D: Unground");
            animator.SetBool(Grounded, false);
        }
    }

    private void OnDisable()
    {
        inputReader.JumpEvent -= OnJump;
        inputReader.SlideEvent -= OnSlide;
    }
}
