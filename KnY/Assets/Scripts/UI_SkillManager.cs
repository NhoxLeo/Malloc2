﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillManager : MonoBehaviour
{
    public SkillManager mySkillManger;
    public List<UI_SkillDisplay> activeSkills = new List<UI_SkillDisplay>();
    public List<UI_PassiveSkillDisplay> passiveSkills = new List<UI_PassiveSkillDisplay>();
    private static List<UI_SkillManager> instances = new List<UI_SkillManager>();

    public void Awake()
    {
        instances.Add(this);
    }
    public static void UpdateSkills()
    {
        foreach(UI_SkillManager instance in Instances)
        {
            if(instance.mySkillManger.ActiveSkills[2] != null)
            { 
                instance.activeSkills[0].Skill = instance.mySkillManger.ActiveSkills[2];
            }
            else
            {
                instance.activeSkills[0].Skill = null;
            }

            if (instance.mySkillManger.ActiveSkills[3] != null)
            {
                instance.activeSkills[1].Skill = instance.mySkillManger.ActiveSkills[3];
            }
            else
            {
                instance.activeSkills[1].Skill = null;
            }

            if (instance.mySkillManger.ActiveSkills[4] != null)
            {
                instance.activeSkills[2].Skill = instance.mySkillManger.ActiveSkills[4];
            }
            else
            {
                instance.activeSkills[2].Skill = null;
            }

            if (instance.mySkillManger.ActiveSkills[5] != null)
            {
                instance.activeSkills[3].Skill = instance.mySkillManger.ActiveSkills[5];
            }
            else
            {
                instance.activeSkills[3].Skill = null;
            }




            if (instance.mySkillManger.PassiveSkills[0] != null)
            {
                instance.passiveSkills[0].Skill = instance.mySkillManger.PassiveSkills[0];
            }
            else
            {
                instance.passiveSkills[0].Skill = null;
            }

            if (instance.mySkillManger.PassiveSkills[1] != null)
            {
                instance.passiveSkills[1].Skill = instance.mySkillManger.PassiveSkills[1];
            }
            else
            {
                instance.passiveSkills[1].Skill = null;
            }
        }
    }

    public static List<UI_SkillManager> Instances
    {
        get
        {
            instances.RemoveAll(item => item == null);
            return instances;
        }

        set
        {
            instances = value;
        }
    }
}
