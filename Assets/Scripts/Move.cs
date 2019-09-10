using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    Rigidbody2D rb2d;
    //Public variables are editable from the Inspector
    public float speed = 5f;
    //Use SerializeField to edit a variable from the inspector even if it's private
    [SerializeField]
    private float flapForce = 20f;
    private bool isDead;

    public GameObject ReplayButton;
    public void UnFreeze()
    {
        Time.timeScale = 1;
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;
        rb2d.velocity = Vector2.zero;
        //Set the ReplayButton to active to show it in the scene.
        ReplayButton.SetActive(true);
        //Change the isDead parameter of the Animator to start the Dead animation
        GetComponent<Animator>().SetBool("isDead", true);
    }
    public void Replay()
    {
        //This line changes the scene to the Scene 0 in your build settings
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        //Freeze time to wait for the player to press Play
        Time.timeScale = 0;
        //Get a reference to the RigidBody2D component
        rb2d = GetComponent<Rigidbody2D>();

        //Set the initial velocity of our Bird
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {




        //Wait for flap Input
        if (Input.GetMouseButtonDown(0))
        {
            // Reset Velocity 
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;

            //Add UP force to the bird
            rb2d.AddForce(Vector2.up * flapForce);
        }

        // Start is called before the first frame update

    }
}
