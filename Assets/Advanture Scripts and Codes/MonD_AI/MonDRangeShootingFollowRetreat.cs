﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonDRangeShootingFollowRetreat : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private bool isWalking;

    public GameObject projectile;
    public Animator animator;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player_Knight_Advanturer").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            //walking
            isWalking = true;
            animator.SetBool("walking", isWalking);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            //shoting
            transform.position = this.transform.position;
            animator.SetTrigger("attack");
            isWalking = false;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            //retreating
            isWalking = true;
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
