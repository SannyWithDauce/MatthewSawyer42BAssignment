using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] float shotCounter;

    [SerializeField] float minTimebetweenshots = 0.2f;

    [SerializeField] float maxTimebetweenshots = 3f;

    [SerializeField] GameObject obstacleBulletPrefab;

    [SerializeField] float obstacleBulletSpeed;

    [SerializeField] int collision = 1;

    [SerializeField] AudioClip ObstacleDeathSound;

    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;

    [SerializeField] float health = 1f;

    [SerializeField] GameObject boom;

    [SerializeField] float explosionDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimebetweenshots, maxTimebetweenshots);
    }

    // Update is called once per frame
    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            ObstacleFire();

            shotCounter = Random.Range(minTimebetweenshots, maxTimebetweenshots);
        }
    }
    private void ObstacleFire()
    {
        GameObject bullet = Instantiate(obstacleBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleBulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        if (health <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, ObstacleDeathSoundVolume);
        GameObject explosion = Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }
}
