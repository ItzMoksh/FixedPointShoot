using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        var particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
        Destroy(gameObject,particles.main.duration); 
    }
}
