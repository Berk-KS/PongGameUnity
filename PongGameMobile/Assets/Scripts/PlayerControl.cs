using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hareketHizi = 2f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch dokunma = Input.GetTouch(0);

            if (dokunma.position.x < Screen.width / 2) // Ekranýn sol tarafýndaki dokunmalara tepki verir
            {
                Vector2 dokunmaPozisyonu = Camera.main.ScreenToWorldPoint(dokunma.position);
                dokunmaPozisyonu.x = transform.position.x;
               // dokunmaPozisyonu.z = 0f;

                transform.position = Vector2.MoveTowards(transform.position, dokunmaPozisyonu, hareketHizi * Time.deltaTime);
            }
        }
    }
}
