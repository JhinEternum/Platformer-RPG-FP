using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private readonly int AttackHash = Animator.StringToHash("attack");
    private readonly int Attack2Hash = Animator.StringToHash("attack2");
    private readonly int AttackingHash = Animator.StringToHash("attacking");
    private InputReader inputReader;
    private Animator animator;

    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputReader.AttackEvent += OnAttack;
    }

    private void OnAttack()
    {
        animator.SetTrigger(AttackHash);
    }

    private void OnDisable()
    {
        inputReader.AttackEvent -= OnAttack;
    }

    private void Update()
    {
    }

}
