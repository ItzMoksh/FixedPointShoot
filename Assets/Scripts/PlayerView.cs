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
    [SerializeField] private Direction currentRotation = Direction.CLOCKWISE;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SwitchRotation();
        }
        transform.Rotate(new Vector3(0, 0, turnAngle * Time.deltaTime * (int)currentRotation));
    }

    private void SwitchRotation()
    {
        Shoot();
        currentRotation = currentRotation == Direction.CLOCKWISE ? Direction.ANTI_CLOCKWISE : Direction.CLOCKWISE;
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.Euler(transform.eulerAngles));
        bullet.transform.position = bulletShootPoint.position;
        BulletView bulletView = bullet.GetComponent<BulletView>();
        bulletView.Init(this, bulletTtl);
        bulletView.CountDownDestroy();
        bulletView.ApplyLinearForce(yBullterForce);
    }

    public void EnemyHit(EnemyView enemyView)
    {
        enemyView.Explode();
    }
}

public enum Direction
{
    CLOCKWISE = 1,
    ANTI_CLOCKWISE = -1
}