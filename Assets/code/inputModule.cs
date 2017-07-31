using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputModule : MonoBehaviour
{
    public Vector3 vector;
    public Vector3 realTouch;
    private float tX;
    private float tY;
    public float resY;
    public flowerManager flowrMan;
    public GameObject qubik;
    // Use this for initialization
    void Start()
    {
        resY = Camera.main.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        

        //realTouch = new Vector3 
        //vector = new Vector3 (resY/2 , 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("as mosue");
        }

        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            RaycastHit hit;
            tX = touch.position.x;
            tY = touch.position.y;

            realTouch = new Vector3(tX / 2, tY / 2, 10);

            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                var ray = Camera.main.ScreenPointToRay(touch.position);

                fingerCount++;

                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
                //Debug.Log("X=" + touch.position.x + "__Y=__" + touch.position.y);

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "flower")
                {
                    Destroy(hit.collider.gameObject);
                    flowrMan.flowerInScene--;
                    Debug.Log("killed " + touch.fingerId + "__flow__  " + hit.collider.gameObject.name);
                    //Instantiate(qubik, hit.point, transform.rotation);
                }

                //Debug.Log(touch.fingerId);

            }



        }
        if (fingerCount > 0)
            print("User has " + fingerCount + " finger(s) touching the screen");



    }
}


