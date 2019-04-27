using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerMisilPrefab;
    public SpriteRenderer ship;
    public float speed = 5.0f;
    public int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-7, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerMisilPrefab, transform.position, Quaternion.identity);
        }
    }

    public void Movement()
    {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.down * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * verticalInput * Time.deltaTime);
    }

    public void Damage()
    {
        lives--;
        if(lives < 1)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Misile")
        {
            Damage();

        }

        if (other.tag == "Meteor")
        {
            Damage();
            ChangeToRed();

        }

        if (other.tag == "Enemy")
        {
            Damage();

        }
    }
    void ChangeToRed()
    {
        ship = GetComponent<SpriteRenderer>();
        ship.color = Color.red;
        StartCoroutine(ChangeToWhite());
    }

    IEnumerator ChangeToWhite()
    {
        yield return new WaitForSeconds(1);
        ship.color = Color.white;
    }

}
