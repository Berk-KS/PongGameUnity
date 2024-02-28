using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Animator animator;
    public int playerid;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        GameManager.instance.onReset += ResetPosition;

    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }



    public void Update()
    {
        // T�m dokunmatik giri�leri al
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Ekran�n sol taraf�nda dokunma alg�land�ysa
            if (touch.position.x < Screen.width / 2 && playerid == 1)
            {
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;
                   
                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
                    Debug.Log("sol taraf");
                }
            }
            // Ekran�n sa� taraf�nda dokunma alg�land�ysa
            else if(touch.position.x >= Screen.width / 2 && playerid == 2)
            {
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary )
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;

                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
                    Debug.Log("sa� taraf");
                    
                }
            }
        }


       // void MovePlayer(int playerNumber, int direction)
       // {
            // Oyuncu hareketi burada i�lenir
            // playerNumber: Oyuncu numaras� (1 veya 2)
            // direction: Hareket y�n� (-1 sola, 1 sa�a)
            // �rne�in, transform.Translate veya Rigidbody kullanabilirsiniz.
       // }
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
           // Debug.Log("�ki nesne �arp��t�!");

            animator.SetTrigger("kig");
            // �stedi�iniz i�lemleri burada yapabilirsiniz.
        }
    }


}
