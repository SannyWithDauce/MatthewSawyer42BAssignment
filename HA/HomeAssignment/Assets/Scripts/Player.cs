using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movespeed = 5f;

    [SerializeField] float health = 20f;

    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.75f;

    [SerializeField] AudioClip playerHitSound;

    float padding = 0.5f;

    float xMin, xMax, yMin, yMax;
    void Start()
    {
        Border();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Border()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);



        transform.position = new Vector2(newXPos, -3);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        print("Hit");
        print(health);
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
