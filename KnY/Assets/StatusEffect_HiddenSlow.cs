﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Slow that is not threated as a debuff by other sources
/// </summary>
public class StatusEffect_HiddenSlow : StatusEffect {

    private float strength = 1;
    public StatusEffect_HiddenSlow(float duration,float strength)
    {
        this.statusName = "Slowed";
        this.description = "Slowed.";
        this.image = null;
        this.duration = duration;
        this.strength = strength;
        this.urgentEffect = true;
    }

    public override void ApplyEffect(GameObject g)
    {
        if(!effectApplied)
        { 
            g.GetComponent<Statusmanager>().movementSpeedMultiplier -= strength;
            effectApplied = true;
        }
    }

    public override void RemoveEffect(GameObject g)
    {
        g.GetComponent<Statusmanager>().movementSpeedMultiplier += strength;
    }

    public override void OnAdditionalApplication(GameObject g, StatusEffect s)
    {
        StatusEffect_HiddenSlow newEffect = (StatusEffect_HiddenSlow)s;
        if(newEffect.duration > duration)
        {
            duration = newEffect.duration;
        }
    }
}
