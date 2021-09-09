using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float speed = 2;
    public float force = 300;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || // Deteccion teclado
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||  // Deteccion toque en pantall
            Input.GetMouseButtonDown(0) ) // Deteccion de mouse
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Application.LoadLevel(Application.loadedLevel); //Esta Obsoleta
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
