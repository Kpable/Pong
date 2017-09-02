using UnityEngine;
using System.Collections;

public class PongPaddle : MonoBehaviour {
    public float speed = 5f;
    public bool opponent;

	void FixedUpdate () {
        //Debug.Log(Input.GetAxisRaw("Vertical"));
        //Debug.Log("Mouse Pos.y: " + Input.mousePosition.y);
        //Debug.Log("StoW Pos.y: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Debug.Log("StoV Pos.y: " + Camera.main.ScreenToViewportPoint(Input.mousePosition).y);

        //Debug.Log("touch 0 Pos.y: " + Input.GetTouch(0).position.y);
        //Debug.Log("StoW Pos.y: " + Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y);
        //Debug.Log("StoV Pos.y: " + Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).y);

        //Debug.Log("touch 1 Pos.y: " + Input.GetTouch(1).position.y);
        //Debug.Log("StoW Pos.y: " + Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position).y);
        //Debug.Log("StoV Pos.y: " + Camera.main.ScreenToViewportPoint(Input.GetTouch(1).position).y);


        if (!opponent)
        {
            //float y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -5.5f, 5.5f);
            //transform.position = new Vector3(transform.position.x, y, 0);
            Vector3 pos = transform.position;
            //if (Application.isWebPlayer || Application.isEditor)
            if (!Application.isMobilePlatform)
            {
                if (Input.GetKey(KeyCode.W) && name.Contains("1"))
                {
                    pos.y += speed * Time.fixedDeltaTime;
                }
                else if (Input.GetKey(KeyCode.S) && name.Contains("1"))
                {
                    pos.y += -speed * Time.fixedDeltaTime;
                }

                if (Input.GetKey(KeyCode.UpArrow) && name.Contains("2"))
                {
                    pos.y += speed * Time.fixedDeltaTime;
                }
                else if (Input.GetKey(KeyCode.DownArrow) && name.Contains("2"))
                {
                    pos.y += -speed * Time.fixedDeltaTime;
                }

            }
            //else if (Application.isMobilePlatform)
            //{
                Touch[] touches = Input.touches;

                for (int i = 0; i < touches.Length; i++)
                {
                Debug.Log(touches[i].position);
                Debug.Log(Camera.main.ScreenToWorldPoint(touches[i].position));
                Vector3 point = Camera.main.ScreenToWorldPoint(touches[i].position);
                if (point.x < 0) // Paddle 1
                {
                    if (point.y > 0 && name.Contains("1"))
                    {
                        pos.y += speed * Time.fixedDeltaTime;
                    }
                    else if (point.y < 0 && name.Contains("1"))
                    {
                        pos.y += -speed * Time.fixedDeltaTime;
                    }
                }
                else if(point.x > 0) // Paddle 2
                {
                    if (point.y > 0 && name.Contains("2"))
                    {
                        pos.y += speed * Time.fixedDeltaTime;
                    }
                    else if (point.y < 0 && name.Contains("2"))
                    {
                        pos.y += -speed * Time.fixedDeltaTime;
                    }
                }
            }

            transform.position = pos;

            //}
            //transform.position = Vector3.MoveTowards(pos, new Vector3(pos.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, pos.z), speed * Time.fixedDeltaTime);

            //pos.y += speed * Time.fixedDeltaTime;



        }

        float y = Mathf.Clamp(transform.position.y, -6.4f, 6.4f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

}
