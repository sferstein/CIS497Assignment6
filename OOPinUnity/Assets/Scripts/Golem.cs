using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Sam Ferstein
 * Assignment 6
 * This is an Enemy subclass.
 */

public class Golem : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        speed = 1f;
        health = 2;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " points of damage");
    }
}
