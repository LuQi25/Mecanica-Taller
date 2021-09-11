using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] public int vidas;
    float minX, maxX;
    
    //float CurrentTime = 0f;
   
    //int asegurarvidas;

    //int puntosDeVida = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;

        //CurrentTime = Startingtime;
        //asegurarvidas = vidas;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        

        if(transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movingRight = true;
        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.timeScale < 1)
        {
            if (collision.gameObject.CompareTag("Disparo"))
            {
                Destroy(this.gameObject);
                gm.ReducirNumEnemigos();
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Disparo"))
            {
                vidas--;
                if (vidas <= 0)
                {
                    Destroy(this.gameObject);
                    gm.ReducirNumEnemigos();
                }
            }
        }
       
    }

    

}