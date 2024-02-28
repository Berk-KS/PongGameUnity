using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rgb2d;
    public float hýz= 4f;
    public float hizArtisMiktari = 1.2f;
    public float maxAçý = 0.67f;

    private float baslangýcX = 0f;
    private float maxBaslangýcY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InitialPush();
    }

    private void InitialPush()
    {
        Vector2 dir = Vector2.left;
        if (Random.value < 0.5f)
            dir = Vector2.right;

        //  alternatif tek satýr yazýmak istersek
        //Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;

        dir.y = Random.Range(-maxAçý, maxAçý);
        rgb2d.velocity = dir * hýz;
    }

    private void ResetBall()
    {
        float posY = Random.Range(-maxBaslangýcY, maxBaslangýcY);
        Vector2 position = new Vector2(baslangýcX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone= collision.GetComponent<ScoreZone>();
        if (scoreZone )
        {
            gameManager.OnScoreZoneReached(scoreZone.id);

            ResetBall();
            InitialPush();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControl player =collision.collider.GetComponent<PlayerControl>();
        if (player)
        {
            rgb2d.velocity *= hizArtisMiktari;
        }

    }
}