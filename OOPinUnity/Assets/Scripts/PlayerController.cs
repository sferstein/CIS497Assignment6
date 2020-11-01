using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Sam Ferstein
 * Assignment 6
 * This is the player controller.
 */

public class PlayerController : MonoBehaviour
{
    private Quaternion rotation;
    private CharacterController controller;
    private Camera camera;
    public Transform firePoint;
    private float bulletSpeed;
    public GameObject bulletPrefab;
    public Text healthText;
    private float playerHealth;
    public bool isGameLost = false;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 10;
        controller = GetComponent<CharacterController>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth;
        mouseMove();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (playerHealth <= 0)
        {
            isGameLost = true;
            Destroy(gameObject);
            loseScreen.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab.transform, firePoint.transform.position, firePoint.transform.rotation);
    }

    void mouseMove()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.transform.position.y - transform.position.y));
        rotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, rotation.eulerAngles.y, 500 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth = playerHealth - 1;
        }
    }
}
