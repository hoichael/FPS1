using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private GameObject _impactEffect;
    [SerializeField]
    private GameObject _impactEnemyEffect;
    [SerializeField]
    private int _damage;
    private Vector3 _enemyPos;

    [SerializeField]
    private bool damagePlayer;
    [SerializeField]
    private bool damageEnemy;


    [SerializeField]
    private bool _isShotgun;

    [SerializeField]
    private GameObject _shotgunBullet;

    [SerializeField]
    private bool _isMegaShotgun;

    [SerializeField]
    private GameObject _megaShotgunBullet;


    //  [SerializeField]
    //  private Transform _bulletTransform;



    /*   void Start()
       {
           if (_isShotgun)
           {

             //  Debug.Log(transform.localEulerAngles);

            //   Vector3 baseDir = new Vector3(_bulletTransform.localEulerAngles.z, _bulletTransform.localEulerAngles.x, _bulletTransform.localEulerAngles.y);

           //    Debug.Log(baseDir);

               Vector3 bulletRot1Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot2Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot3Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot4Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot5Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot6Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
               Vector3 bulletRot7Vector = new Vector3(Random.Range(-10f, 10.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));

               Quaternion bulletRot1 = Quaternion.Euler(bulletRot1Vector);
               Quaternion bulletRot2 = Quaternion.Euler(bulletRot2Vector);
               Quaternion bulletRot3 = Quaternion.Euler(bulletRot3Vector);
               Quaternion bulletRot4 = Quaternion.Euler(bulletRot4Vector);
               Quaternion bulletRot5 = Quaternion.Euler(bulletRot5Vector);
               Quaternion bulletRot6 = Quaternion.Euler(bulletRot6Vector);
               Quaternion bulletRot7 = Quaternion.Euler(bulletRot7Vector);

               Instantiate(_shotgunBullet, transform.position, bulletRot1);
               Instantiate(_shotgunBullet, transform.position, bulletRot2);
               Instantiate(_shotgunBullet, transform.position, bulletRot3);
               Instantiate(_shotgunBullet, transform.position, bulletRot4);
               Instantiate(_shotgunBullet, transform.position, bulletRot5);
               Instantiate(_shotgunBullet, transform.position, bulletRot6);
               Instantiate(_shotgunBullet, transform.position, bulletRot7);

               //destroy game object


           }
       } */

    void Update()
    {         
        _rb.velocity = transform.forward * _moveSpeed;

        _lifeTime -= Time.deltaTime;

        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            _enemyPos = new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z);
            Instantiate(_impactEnemyEffect, _enemyPos + (transform.forward * (-_moveSpeed * Time.deltaTime)), other.transform.rotation);
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(_damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player" && damagePlayer)
        {
            Debug.Log("yoyoyo" + transform.position);
            PlayerHealthController.instance.DamagePlayer(_damage);
            Destroy(gameObject);
        }
        else
        {            
            Instantiate(_impactEffect, transform.position + (transform.forward * (-_moveSpeed * Time.deltaTime)), transform.rotation);
            Destroy(gameObject);
        }

       if(_shotgunBullet)
       {
            Vector3 bulletRot1Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot2Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot3Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot4Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot5Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot6Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot7Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot8Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot9Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot10Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot11Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot12Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot13Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot14Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot15Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));
            Vector3 bulletRot16Vector = new Vector3(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f));


            Quaternion bulletRot1 = Quaternion.Euler(bulletRot1Vector);
            Quaternion bulletRot2 = Quaternion.Euler(bulletRot2Vector);
            Quaternion bulletRot3 = Quaternion.Euler(bulletRot3Vector);
            Quaternion bulletRot4 = Quaternion.Euler(bulletRot4Vector);
            Quaternion bulletRot5 = Quaternion.Euler(bulletRot5Vector);
            Quaternion bulletRot6 = Quaternion.Euler(bulletRot6Vector);
            Quaternion bulletRot7 = Quaternion.Euler(bulletRot7Vector);
            Quaternion bulletRot8 = Quaternion.Euler(bulletRot8Vector);
            Quaternion bulletRot9 = Quaternion.Euler(bulletRot9Vector);
            Quaternion bulletRot10 = Quaternion.Euler(bulletRot10Vector);
            Quaternion bulletRot11 = Quaternion.Euler(bulletRot11Vector);
            Quaternion bulletRot12 = Quaternion.Euler(bulletRot12Vector);
            Quaternion bulletRot13 = Quaternion.Euler(bulletRot13Vector);
            Quaternion bulletRot14 = Quaternion.Euler(bulletRot14Vector);
            Quaternion bulletRot15 = Quaternion.Euler(bulletRot15Vector);
            Quaternion bulletRot16 = Quaternion.Euler(bulletRot16Vector);

            if(_isMegaShotgun)
            {
                Instantiate(_megaShotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot1);
                Instantiate(_megaShotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot2);
                Instantiate(_megaShotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot3);
                Instantiate(_megaShotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot4);
                Instantiate(_megaShotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot5);
            }
            else
            {
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot1);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot2);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot3);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot4);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot5);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot6);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot7);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot8);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot9);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot10);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot11);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot12);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot13);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot14);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot15);
                Instantiate(_shotgunBullet, transform.position + (transform.forward * (-1f)), bulletRot16);
            }

        }
        
    }
}
