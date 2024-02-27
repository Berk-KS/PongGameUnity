using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Animator animator;


    void Update()
    {
        // T�m dokunmatik giri�leri al
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Ekran�n sol taraf�nda dokunma alg�land�ysa
            if (touch.position.x < Screen.width / 2)
            {
                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;
  
                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
                }
            }
            // Ekran�n sa� taraf�nda dokunma alg�land�ysa
            else
            {
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;

                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);

                    Debug.Log("sa� taraf");
                }
            }







        }


        void MovePlayer(int playerNumber, int direction)
        {
            // Oyuncu hareketi burada i�lenir
            // playerNumber: Oyuncu numaras� (1 veya 2)
            // direction: Hareket y�n� (-1 sola, 1 sa�a)
            // �rne�in, transform.Translate veya Rigidbody kullanabilirsiniz.
        }


        /*
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);

          /*  if (dokunma.position.x < Screen.width / 2) // Ekran�n sol taraf�ndaki dokunmalara tepki verir
            {
                Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(dokunma.position);
                dokunmaPozisyonu.x = transform.position.x;
                // dokunmaPozisyonu.z = 0f;
                Debug.Log("ekran�n solu");
                transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
            }
            if (dokunma.position.x >= Screen.width / 2) // Ekran�n sa� taraf�ndaki dokunmalara tepki verir 
            {
                Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(dokunma.position);
                dokunmaPozisyonu.x = transform.position.x;
                //dokunmaPozisyonu.z = 0f;
                Debug.Log("ekran�n sa��");
                transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
            }
            

        }
        */
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("�ki nesne �arp��t�!");

            animator.SetTrigger("kig");
            // �stedi�iniz i�lemleri burada yapabilirsiniz.
        }
    }


}
