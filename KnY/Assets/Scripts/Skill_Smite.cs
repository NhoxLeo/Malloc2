﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Skill_Smite : Skill
{
    private float projectileSpeed = 1;
    public int pietyDamage = 2;
    private Vector3 mousePosOnActivation;

    /// <summary>
    /// Initializes base Skill Atributes
    /// </summary>
    public Skill_Smite(float cooldown, float casttime,float projectileSpeed,bool allowsMovement)
    {
        this.Cooldown = cooldown;
        this.Casttime = casttime;
        this.BaseCooldown = cooldown;
        this.BaseCasttime = casttime;
        this.AllowsMovement = allowsMovement;
        this.projectileSpeed = projectileSpeed;
        this.SpCost = 20;
        this.Name = "Smite";
        this.Description = "Deals damage for" + pietyDamage * 100 + "% Piety.";
        this.Image = ItemIcons.GetSkillIcon(17);
    }


    /// <summary>
    /// Sets Parameter for Skill Actiavtion
    /// </summary>
    public override void ActivateSkill(GameObject source, Vector2 direction, Vector2 position, GameObject target)
    {
        mousePosOnActivation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calculate Attackspeed
        base.ActivateSkill(source,direction, position, target);
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
            GroundAoeIndicator.InstantiateGroundAoeIndicator(Position, new Vector2(1, 1), Casttime);
            InitialApplication = true;
        }
    }

    public override void OnCastEnd(GameObject source)
    {
        if (Anim != null)
        {
            Anim.SetInteger("AnimationState", 2);
        }
        Statusmanager s = source.GetComponent<Statusmanager>();
        s.StartCoroutine(Acceleration(source));
    }

    IEnumerator Acceleration(GameObject source)
    {
        yield return new WaitForSeconds(0.2f);
        Direction = PublicGameResources.CalculateNormalizedDirection(source.transform.position, Position);

        FxMaterial = source.GetComponent<SpriteRenderer>().material;
        Statusmanager s = source.GetComponent<Statusmanager>();
        GameObject fx = GameObject.Instantiate(PublicGameResources.GetResource().damageFx, source.transform.position, Quaternion.identity);
        GameObject projectile = GameObject.Instantiate(PublicGameResources.GetResource().damageObject, source.transform.position, Quaternion.identity);
        projectile.GetComponent<DamageObject>().SetValues(s.Piety * pietyDamage, s.criticalStrikeChance, 0, 10f, source, 6);
        projectile.GetComponent<SpriteRenderer>().material = FxMaterial;
        projectile.transform.GetChild(5).GetComponent<CircleCollider2D>().radius = 0.09f;
        projectile.GetComponent<Animator>().SetFloat("DamageAnimation", 0);
        fx.transform.SetParent(projectile.transform);
        fx.GetComponent<SpriteRenderer>().material = PublicGameResources.GetResource().pietyMaterial;
        fx.transform.Find("DamageObjectParticles1").gameObject.SetActive(true);
        fx.transform.right = ((Vector2)Position - (Vector2)source.transform.position);
        fx.GetComponent<Animator>().SetFloat("DamageAnimation", 16);
        fx.GetComponent<Animator>().SetBool("LoopAnimation", true);


        int timer = 0;
        while(timer < 25)
        {
            projectile.GetComponent<Rigidbody2D>().AddForce(Direction * projectileSpeed);
            timer++;
            yield return new WaitForSeconds(0.05f);
        }
    }


}
