﻿using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PlayerStaminaBar : MonoBehaviour
{

    [Header("References")]
    public Slider staminaBar;
    public RigidbodyFirstPersonController movementScript;

    [Header("Values")]
    public float maxStamina = 100f;
    public float staminaDecrease = 10f;
    public float staminaRegen = 2f;
    public float minStamina = 0.5f;
    public bool canSprint = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForStamina();
        UpdateSlider();
        StaminaRegen();
    }

    void CheckForStamina()
    {
        if (staminaBar.value <= minStamina && movementScript.Running)
        {
            canSprint = false;
        }
        else
        {
            canSprint = true;
        }
    }

    void UpdateSlider()
    {
        if (canSprint)
        {
            if (movementScript.Running)
            {
                staminaBar.value -= Time.deltaTime * staminaDecrease;
            }
        }
        else
        {
            StaminaRegen();
        }
    }

    void StaminaRegen()
    {
        if (staminaBar.value < maxStamina)
        {
            StartCoroutine(WaitForRegen());
            staminaBar.value += Time.deltaTime * staminaRegen;
        }
    }
}
