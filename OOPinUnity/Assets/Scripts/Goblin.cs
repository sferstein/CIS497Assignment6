using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Sam Ferstein
 * Assignment 6
 * This is an Enemy subclass.
 */

public class Goblin : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        speed = 2f;
        health = 1;
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took " + amount + " points of damage");
    }
}