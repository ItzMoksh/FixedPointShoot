using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private PlayerView playerView = null;
    private Rigidbody2D bulletRg = null;


    private float ttl = 0f;


    public void Init(PlayerView playerView, float ttl)
    {
        this.playerView = playerView;
        bulletRg = GetComponent<Rigidbody2D>();
        this.ttl = ttl;
    }

    public void ApplyLinearForce(float yForce)
    {
        bulletRg.AddForce(transform.up * yForce, ForceMode2D.Impulse);
    }

    public void CountDownDestroy()
    {
        // StartCoroutine(CountDownDestroyEnumerator());
    }

    private IEnumerator CountDownDestroyEnumerator()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerView.EnemyHit(collision.gameObject.GetComponent<EnemyView>());
        }
        else if (collision.gameObject.tag == "Wall")
        {
        }
        Destroy(gameObject);    
    }
}
