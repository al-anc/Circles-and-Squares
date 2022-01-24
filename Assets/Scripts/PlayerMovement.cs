using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    float currentTime = 0f;
    float startingTime = 10f;
    float readyTime = 2f;

    [SerializeField] Text countdownText;
    [SerializeField] Text winText;

    void Start()
    {
        currentTime = startingTime;
    }
    
    void Update() {
        MovementInput();

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");

        if (currentTime <= 0 ) {
            currentTime = 0;
        }

        if (Input.GetKey(KeyCode.R)) {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Circle")){
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Square")){
            Destroy(this);
            Destroy(other.gameObject);
            countdownText.text = "You Lose. Press R to Try again.";
        }
    }
    

    void MovementInput () {
         float mx = Input.GetAxisRaw("Horizontal");
         float my = Input.GetAxisRaw("Vertical");

         movement = new Vector2(mx, my).normalized;
    }
}