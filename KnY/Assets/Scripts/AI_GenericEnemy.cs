﻿using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_GenericEnemy : AI_BaseAI
{

    public Transform bodyTransform;


    void Start()
    {
        Initialize();
    }
	// Update is called once per frame
	void Update () {
        AttackCooldownTimerUpdate();
        if ((mode != Mode.AttackPrep && mode != Mode.Attack && mode != Mode.Idle && mode != Mode.IdleAfterAttack && mode != Mode.Wander) )
        {
            TurnToTarget(SearchTarget());
            if (CheckLineOfSightPathfinding())
            {
                mode = Mode.RegularFollow;
            }
            else
            {
                mode = Mode.PathfinderFollow;
            }
            if (CheckAttackConditions())
            {
                mode = Mode.AttackPrep;
                rb.velocity = Vector2.zero;
            }
        }
        HandleEffects();
        switch(mode)
        {
            case Mode.Idle:
                if (Target != null) // If I can attack, I will go in range
                {
                    mode = Mode.RegularFollow;
                }
                if (Target == null) // I don't have a target? I have to search target, uga buga!
                {
                    CheckAggroRadius();
                }
                PathFindingActive(false); // I'm not gonna move
                rb.velocity = Vector2.zero; // Not even a little bit
                break;
            case Mode.IdleAfterAttack:
                if (attackCooldownTimer <= 0 && Target != null) // If I can attack, I will go in range
                {
                    mode = Mode.RegularFollow;
                }
                if (Target != null && IsMyTargetDead(Target)) // Is my target dead? Back to Full Idle
                {
                    mode = Mode.Idle;
                    Target = null;
                }
                if (Target == null) // I don't have a target? I have to search target, uga buga!
                {
                    CheckAggroRadius();
                }
                PathFindingActive(false); // I'm not gonna move
                rb.velocity = Vector2.zero; // Not even a little bit
                break;
            case Mode.PathfinderFollow:
                if(IsMyTargetDead(Target))  // Is my target dead? Back to Full Idle
                {
                    mode = Mode.Idle;
                    Target = null;
                    break;
                }
                PathFindingActive(true); // Gonna follow the path
                break;
            case Mode.RegularFollow:
                if (IsMyTargetDead(Target))  // Is my target dead? Back to Full Idle
                {
                    mode = Mode.Idle;
                    Target = null;
                    break;
                }
                PathFindingActive(false); // Not gonna follow the path
                MoveToPlayer(); // Good old stalker movement
                break;
            case Mode.AttackPrep:
                foreach(Animator a in attackingAnimators)
                { 
                    a.SetInteger("AnimationState", 2);
                }
                PathFindingActive(false);  // not gonna move
                PrepareForAttack(0.5f); // preparing my attack
                break;
            case Mode.Wander:
                PathFindingActive(false); // No pathfing for me
                GetWanderPosition(3); // Where should I wander
                GoToWanderPositon(); // Off i go!
                if (Target == null) // I don't have a target? I have to search target, uga buga!
                {
                    if(null != CheckAggroRadius())
                    {
                        mode = Mode.RegularFollow;
                    }
                }
                break;
            case Mode.Attack:
                foreach (Animator a in attackingAnimators)
                {
                    a.SetInteger("AnimationState", 3);
                }

                JumpAttack(1.2f); // CHAAAAARGE!
                break;
        }
    }

    public bool AttackPlayer()
    {
        if (Target != null && 0.3f > Vector2.Distance(bodyTransform.position, Target.transform.position))
        {
            if(!isAttacking)
            { 
                rb.velocity = Vector2.zero;
                isAttacking = true;
                StartCoroutine(InitiateAttack());
            }
            return true;
        }
        return false;
    }

    IEnumerator InitiateAttack()
    {
        Vector2 heading = Target.transform.position - transform.position;
        direction = heading / Vector2.Distance(bodyTransform.position, Target.transform.position);
        float timer = attackDelay;
        foreach(Animator a in attackingAnimators)
        {
            a.SetBool("Attack", true);
        }
        for (float timeElapsed = 0; timeElapsed <= attackDelay / Director.TimeScale(); timeElapsed += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();
            foreach (Animator a in attackingAnimators)
            {
                a.SetBool("Attack", false);
            }
        }
        GameObject damageObject = Instantiate(PublicGameResources.GetResource().damageObject, (Vector2)bodyTransform.position + direction * 0.2f, Quaternion.identity);
        damageObject.GetComponent<DamageObject>().SetValues(GetComponent<Statusmanager>().TotalAttackDamage, GetComponent<Statusmanager>().CriticalStrikeChance, 0f, 0.07f, gameObject, 5);
        damageObject.GetComponent<Animator>().SetFloat("DamageAnimation", 11);
        damageObject.GetComponent<DamageObject>().SetKnockbackParameters(0.4f,0.1f);
        damageObject.transform.right = direction * -1;
        isAttacking = false;
    }
}
