using UnityEngine;
using System.Collections;

public class PongBall : MonoBehaviour {

    public float ballSpeed;
    public AudioClip hit;

    void Start()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(ballSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(hit, transform.position);
    }

    public void Reset(string paddleName)
    {
        float shift = 0;
        if (paddleName.Contains("1")) shift = .5f;
        else shift = -.5f;

        Vector3 pos = GameObject.Find(paddleName).transform.position;
        pos.x += shift;
        transform.position = pos;
    }
}
