using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Sam Ferstein
 * Assignment 6
 * This is the main class for enemies.
 */

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;
    public float chaseDist;
    private Transform player;
    private bool isChasing;

    [SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        weapon = gameObject.AddComponent<Weapon>();

        speed = 5f;
        health = 1;

        weapon.damageBonus = 10;
    }

    public abstract void TakeDamage(int amount);

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards3D();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MoveTowards3D()
    {
        if (Vector3.Distance(transform.position, player.position) >= chaseDist)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }
}
