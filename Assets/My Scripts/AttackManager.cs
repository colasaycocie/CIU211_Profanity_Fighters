﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour {

    private int attackDamage;               // The amount of health taken away per attack.

    [Header("Cooldowns")]
    public static int mediumAttack1Cooldown = 3;
    public static int mediumAttack2Cooldown = 3;
    public static int mediumAttack3Cooldown = 3;
    public static int heavyAttackCooldown = 5;
    private static bool MA1Cooldown;
    private static bool MA2Cooldown;
    private static bool MA3Cooldown;
    private static bool HACooldown;
    public Text MA1CooldownText;
    public GameObject MA1CooldownButton;
    public Text MA2CooldownText;
    public GameObject MA2CooldownButton;
    public Text MA3CooldownText;
    public GameObject MA3CooldownButton;
    public Text HACooldownText;
    public GameObject HACooldownButton;

    Animator anim;                              // Reference to the animator component.
    GameObject enemy;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.

    public enemyAttackManager enemyAttackManager;

    [Header("Attack Prefabs")]
    public GameObject lightAttack1;
    public GameObject lightAttack2;
    public GameObject lightAttack3;
    public GameObject mediumAttack1;
    public GameObject mediumAttack2;
    public GameObject mediumAttack3;
    public GameObject heavyAttack;

    private GameObject instantiatedlightAttack1;
    private GameObject instantiatedlightAttack2;
    private GameObject instantiatedlightAttack3;
    private GameObject instantiatedmediumAttack1;
    private GameObject instantiatedmediumAttack2;
    private GameObject instantiatedmediumAttack3;
    private GameObject instantiatedheavyAttack;

    static public bool activateAttack = true;

    void Start()
    {
        // Setting up the references.
        enemyAttackManager = FindObjectOfType<enemyAttackManager>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    public void OnClick()
    {
        // When clicking a certain button, a text is instantiated.

        if(activateAttack == true && enemyAttackManager.canAttack == false)
        {
            //Debug.Log("" + activateAttack);

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton1")
            {

               StartCoroutine("Attack");

               attackDamage = 5;

               //activateAttack = false;

               instantiatedlightAttack1 = (GameObject)Instantiate(lightAttack1, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedlightAttack1.gameObject, 2f);
                

            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton2")
            {

               StartCoroutine("Attack");

               attackDamage = 10;

               //activateAttack = false;

               instantiatedlightAttack2 = (GameObject)Instantiate(lightAttack2, transform.position, transform.rotation);

               // After 2 seconds the text is destroyed.
               Destroy(instantiatedlightAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "LightAttackButton3")
            {

                StartCoroutine("Attack");

                //activateAttack = false;

                attackDamage = 15;

                instantiatedlightAttack3 = (GameObject)Instantiate(lightAttack3, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedlightAttack3.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton1" && MA1Cooldown == false)
            {

                MA1Cooldown = true;

                StartCoroutine("Attack");

                //activateAttack = false;

                attackDamage = 15;

                instantiatedmediumAttack1 = (GameObject)Instantiate(mediumAttack1, transform.position, transform.rotation);



               // After 2 seconds the text is destroyed.
               Destroy(instantiatedmediumAttack1.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton2" && MA2Cooldown == false)
            {
                MA2Cooldown = true;

                StartCoroutine("Attack");

                //activateAttack = false;

                attackDamage = 15;

                instantiatedmediumAttack2 = (GameObject)Instantiate(mediumAttack2, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedmediumAttack2.gameObject, 2f);

            }

            if (EventSystem.current.currentSelectedGameObject.name == "MediumAttackButton3" && MA3Cooldown == false)
            {
                MA3Cooldown = true;

                StartCoroutine("Attack");

                //activateAttack = false;

                attackDamage = 15;

                instantiatedmediumAttack3 = (GameObject)Instantiate(mediumAttack3, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedmediumAttack3.gameObject, 2f);
                
            }

            if (EventSystem.current.currentSelectedGameObject.name == "HeavyAttackButton" && HACooldown == false)
            {
                HACooldown = true;

                StartCoroutine("Attack");

                //activateAttack = false;

                attackDamage = 30;

                instantiatedheavyAttack = (GameObject)Instantiate(heavyAttack, transform.position, transform.rotation);

                // After 2 seconds the text is destroyed.
                Destroy(instantiatedheavyAttack.gameObject, 2f);
                
            }
        }
    }

    void Update()
    {
        //Debug.Log(mediumAttack1Cooldown);
        //Debug.Log("" + activateAttack);
    }

    void Cooldowns()
    {
        if (MA1Cooldown == true)
        {
            MA1CooldownButton.SetActive(true);
            mediumAttack1Cooldown -= 1;

            MA1CooldownText.text = "" + mediumAttack1Cooldown;

            if (mediumAttack1Cooldown <= 0)
            {

                MA1Cooldown = false;
                mediumAttack1Cooldown = 3;
                MA1CooldownText.text = "" + mediumAttack1Cooldown;
                MA1CooldownButton.SetActive(false);
            }
        }

        if (MA2Cooldown == true)
        {
            MA2CooldownButton.SetActive(true);
            mediumAttack2Cooldown -= 1;

            MA2CooldownText.text = "" + mediumAttack2Cooldown;

            if (mediumAttack2Cooldown <= 0)
            {

                MA2Cooldown = false;
                mediumAttack2Cooldown = 2;
                MA2CooldownText.text = "" + mediumAttack2Cooldown;
                MA2CooldownButton.SetActive(false);
            }
        }

        if (MA3Cooldown == true)
        {
            MA3CooldownButton.SetActive(true);
            mediumAttack3Cooldown -= 1;

            MA3CooldownText.text = "" + mediumAttack3Cooldown;

            if (mediumAttack3Cooldown <= 0)
            {

                MA3Cooldown = false;
                mediumAttack3Cooldown = 2;
                MA3CooldownText.text = "" + mediumAttack3Cooldown;
                MA3CooldownButton.SetActive(false);
            }
        }

        if (HACooldown == true)
        {

            HACooldownButton.SetActive(true);
            heavyAttackCooldown -= 1;

            HACooldownText.text = "" + heavyAttackCooldown;

            if (heavyAttackCooldown <= 0)
            {

                HACooldown = false;
                heavyAttackCooldown = 5;
                HACooldownText.text = "" + heavyAttackCooldown;
                HACooldownButton.SetActive(true);
            }
        }
    }

    public IEnumerator Attack()
    {
        Cooldowns();
        activateAttack = false;
        yield return new WaitForSeconds(2f);

        //activateAttack = true;

        if (enemyHealth.enemyCurrentHealth > 0)
        {
            // ... damage the player.
            enemyHealth.TakeDamage(attackDamage);
            Debug.Log("Enemy Health: " + enemyHealth.enemyCurrentHealth);
        }
    }
}
