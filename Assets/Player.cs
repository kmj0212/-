using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public float movePower = 1f;
    public GameObject gameOverUI;
    Rigidbody2D rigid;

    Vector3 movement;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        gameOverUI.SetActive(false);
    }

   
   
    void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("FallingObject"))
        {
           
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
