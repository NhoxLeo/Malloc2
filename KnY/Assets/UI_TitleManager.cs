﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleManager : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    private bool animate = false;
    private float fade = 1;
    private int mod = 1;
    private float timer = 0;

    public Text levelName;
    public Text levelDescription;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Material material in materials)
        {
            material.SetFloat("_Fade", 0);
        }
        print("Showing Level Title");
        Show(3);
    }
    



    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
            fade += mod * Time.deltaTime * 1.2f;
            if (fade >= 1 || fade <= 0)
            {
                animate = false;
            }
            foreach (Material material in materials)
            {
                material.SetFloat("_Fade", fade);
            }
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            Hide();
            timer = 0;
        }
    }

    public void Show()
    {
        animate = true;
        fade = 0;
        mod = 1;
    }

    public void Show(float durration)
    {
        animate = true;
        fade = 0;
        timer = durration;
        mod = 1;
    }

    public void Hide()
    {
        animate = true;
        fade = 1;
        mod = -1;
    }

    public void SetTitleProperties(string name, string description)
    {
        levelName.text = name;
        levelDescription.text = description;
    }
}