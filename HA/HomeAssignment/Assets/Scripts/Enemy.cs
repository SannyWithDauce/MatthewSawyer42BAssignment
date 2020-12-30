using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float shotCounter;

    [SerializeField] float minTimebetweenshots = 0.2f;

    [SerializeField] float maxTimebetweenshots = 3f;

    [SerializeField] GameObject enemyBulletPrefab;

    [SerializeField] float enemyBulletSpeed;

    [SerializeField] int collision = 1;

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

        if(shotCounter <= 0f)
        {
            EnemyFire();

            shotCounter = Random.Range(minTimebetweenshots, maxTimebetweenshots);
        }
    }
    private void EnemyFire()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-enemyBulletSpeed);
    }
}
