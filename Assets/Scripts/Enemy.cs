using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject enemyMisilePrefab;
    public float speed = 5.0f;
    public int timesHited = 0;
    public int enemyLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(7,0,0);
       //nstantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.x < -10)
        {
            float randomY = Random.Range(-7f, 7f);
            transform.position = new Vector3(30, randomY, 0); 
        }
    }

    void Shoot()
    {
        Instantiate(enemyMisilePrefab, transform.position, Quaternion.identity);
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Misile")
        {
            timesHited++;
            if(timesHited >= 3)
            {
                Destroy(other.gameObject);

                Destroy(this.gameObject);
            }
            
        }

        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
                
            }

           
        }
    }

  

}
