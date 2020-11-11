﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damageDoneFireB = -50;
    private float speedOfFireBall = 100f;
    void Start()
    {
        rb.velocity = transform.right * speedOfFireBall;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Knight")
        {
            HealthKnight eHealth = other.gameObject.GetComponent<HealthKnight>();
            eHealth.ModifyHealth(damageDoneFireB);
        }
        else
        {
            if (other.gameObject.tag == "Player_Hunter")
            {
                HealthHunter eHealth = other.gameObject.GetComponent<HealthHunter>();
                eHealth.ModifyHealth(damageDoneFireB);
            }
        }
        Destroy(gameObject);
    }
}
