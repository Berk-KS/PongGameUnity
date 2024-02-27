using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Animator animator;


    void Update()
    {
        // Tüm dokunmatik giriþleri al
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // Ekranýn sol tarafýnda dokunma algýlandýysa
            if (touch.position.x < Screen.width / 2)
            {
                if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;
  
                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
                }
            }
            // Ekranýn sað tarafýnda dokunma algýlandýysa
            else
            {
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(touch.position);
                    dokunmaPozisyonu.x = transform.position.x;

                    transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);

                    Debug.Log("sað taraf");
                }
            }







        }


        void MovePlayer(int playerNumber, int direction)
        {
            // Oyuncu hareketi burada iþlenir
            // playerNumber: Oyuncu numarasý (1 veya 2)
            // direction: Hareket yönü (-1 sola, 1 saða)
            // Örneðin, transform.Translate veya Rigidbody kullanabilirsiniz.
        }


        /*
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);

          /*  if (dokunma.position.x < Screen.width / 2) // Ekranýn sol tarafýndaki dokunmalara tepki verir
            {
                Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(dokunma.position);
                dokunmaPozisyonu.x = transform.position.x;
                // dokunmaPozisyonu.z = 0f;
                Debug.Log("ekranýn solu");
                transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
            }
            if (dokunma.position.x >= Screen.width / 2) // Ekranýn sað tarafýndaki dokunmalara tepki verir 
            {
                Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(dokunma.position);
                dokunmaPozisyonu.x = transform.position.x;
                //dokunmaPozisyonu.z = 0f;
                Debug.Log("ekranýn saðý");
                transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
            }
            

        }
        */
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ýki nesne çarpýþtý!");

            animator.SetTrigger("kig");
            // Ýstediðiniz iþlemleri burada yapabilirsiniz.
        }
    }


}
