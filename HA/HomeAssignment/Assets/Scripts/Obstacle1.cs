using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    [SerializeField] int collision = 1;

    [SerializeField] AudioClip ObstacleDeathSound;

    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;

    [SerializeField] float health = 1f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, ObstacleDeathSoundVolume);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
