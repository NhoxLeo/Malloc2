﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PassiveSkillAttribute_Glass : PassiveSkillAttribute
{
    private StatusEffect myEffectRefference;
    
    public PassiveSkillAttribute_Glass()
    {
        this.Name = "Glass";
    }

    public override void ApplyEffect(GameObject source)
    {
        if(myEffectRefference == null)
        {
            myEffectRefference = new StatusEffect_Glass();
            myEffectRefference = source.GetComponent<Statusmanager>().ApplyStatusEffect(myEffectRefference);
        }
    }

    public override void RemoveEffect(GameObject source)
    {
        myEffectRefference.RemoveStacks(1);
        if (myEffectRefference.stacks == 0)
        {
            myEffectRefference.duration = 0;
            myEffectRefference = null;
        }
    }
}
