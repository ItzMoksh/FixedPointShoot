using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform bulletShootPoint = null;
    [SerializeField] private float turnAngle = 20f;
    [SerializeField] private float yBullterForce = 20f;
    [SerializeField] private float bulletTtl = 5f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Turn(TurnDirection.LEFT);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Turn(TurnDirection.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Turn(TurnDirection direction)
    {
        transform.Rotate(new Vector3(0, 0, turnAngle * (int)direction));
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.Euler(transform.eulerAngles));
        bullet.transform.position = bulletShootPoint.position;
        BulletView bulletView = bullet.GetComponent<BulletView>();
        bulletView.Init(this,bulletTtl);
        bulletView.CountDownDestroy();
        bulletView.ApplyLinearForce(yBullterForce);
    }

    public void EnemyHit(EnemyView enemyView)
    {
        Destroy(enemyView.gameObject);
    }
}

public enum TurnDirection
{
    LEFT = -1,
    RIGHT = 1
}