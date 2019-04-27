using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMisile : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Misile")
    //    {

    //        Destroy(other.gameObject);
    //        Destroy(this.gameObject);
    //    }

    //    if (other.tag == "Player")
    //    {
    //        Player player = other.GetComponent<Player>();

    //        if (player != null)
    //        {
    //            player.Damage();
    //        }

    //        Destroy(this.gameObject);
    //    }
    //}

    }

