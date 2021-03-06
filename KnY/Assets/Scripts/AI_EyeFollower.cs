﻿using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_EyeFollower : AI_BaseFollowerAI
{

    public Transform bodyTransform;
    public float leachRange;
	
    void Start()
    {
        Initialize();
        targetIsFollowTarget = false;
        GetComponent<AIDestinationSetter>().target = followTarget.transform;
        skills.Add(new Skill_Laser(7, 0.5f, 0.75f, 3f, true));
        foreach(Skill skill in skills)
        {
            skill.Anim = bodyTransform.GetComponent<Animator>();
        }
    }
	// Update is called once per frame
	void Update () {
        AttackCooldownTimerUpdate();
        if(Target != null && Target.GetComponent<Statusmanager>().Hp <= 0)
        {
            print("Condition met");
            Target = GetRandomTargetInRange();
            skills[0].Target = Target;
        }
        if((skills[0].CooldownTimer <= 0))
        { 
            Target = GetRandomTargetInRange();
        }
        if (Target != null) 
        {
            mode = Mode.Attack;
        }
        else
        {
            mode = Mode.Idle;
        }
        switch(mode)
        {
            case Mode.Idle:
                break;
            case Mode.Attack:
                if (skills[0].CooldownTimer <= 0)
                {
                    skills[0].ActivateSkill(gameObject, Vector2.zero,Vector2.zero, Target);
                }
                break;
        }
        UpdateTimers();
    }

}
