﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Skill_Cure : Skill
{

    private Material initialMaterial;
    /// <summary>
    /// Initializes base Skill Atributes
    /// </summary>
    public Skill_Cure(float cooldown, float casttime,bool allowsMovement)
    {
        this.Cooldown = cooldown;
        this.Casttime = casttime;
        this.BaseCooldown = cooldown;
        this.BaseCasttime = casttime;
        this.AllowsMovement = allowsMovement;
        this.Name = "Cure";
        this.Description = "Heals you for 20% of your Magic Power + 250% of your <Color=yellow>PIE</color>";
        this.SpCost = 50;
        this.FxMaterial = PublicGameResources.GetResource().healingMaterial;
        this.Image = ItemIcons.GetSkillIcon(4);
    }


    /// <summary>
    /// Sets Parameter for Skill Actiavtion
    /// </summary>
    public override void ActivateSkill(GameObject source, Vector2 direction, Vector2 position, GameObject target)
    {
        initialMaterial = source.GetComponent<SpriteRenderer>().material;
        source.GetComponent<SpriteRenderer>().material = FxMaterial;
        // Calculate Attackspeed
        base.ActivateSkill(source, direction, position, target);
    }

    /// <summary>
    /// Casts the skill
    /// </summary>
    public override void SkillCastingPhase(GameObject source)
    {
        if (!InitialApplication)
        {
            if (Anim != null)
            {
                Anim.SetInteger("AnimationState", 1);
            }
            InitialApplication = true;
        }
    }

    public override void OnCastEnd(GameObject source)
    {
        if (Anim != null)
        {
            Anim.SetInteger("AnimationState", 2);
        }
        source.GetComponent<Statusmanager>().StartCoroutine(Cure(source));
    }

    IEnumerator Cure(GameObject source)
    {
        yield return new WaitForSeconds(0.4f);
        Statusmanager s = source.GetComponent<Statusmanager>();
        int healAmount = (int)(source.GetComponent<Statusmanager>().TotalMagicPower * 0.2f + s.Piety * 2.5f);
        s.Hp += healAmount;
        Director.GetInstance().SpawnDamageText(healAmount.ToString(), source.transform, Color.green, false);
        yield return new WaitForSeconds(0.4f);
        source.GetComponent<SpriteRenderer>().material = initialMaterial;
    }



}
