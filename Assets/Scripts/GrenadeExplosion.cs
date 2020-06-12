using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{

    public GameObject grenadeExplosionEffect;
    public int _damage;
    public float _lifeTime;

    void Start()
    {
        Instantiate(grenadeExplosionEffect, transform.position, transform.rotation);
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("yoyoyo");
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(_damage);
            Destroy(other.gameObject);
        }
    }

}
