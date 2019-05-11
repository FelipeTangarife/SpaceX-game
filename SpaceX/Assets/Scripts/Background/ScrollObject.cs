using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {

    public float scrollspeed = -2f;
    private Rigidbody2D rb2d;
    private Renderer rend;
    private float hLength;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        hLength = rend.bounds.size.x;
        Debug.Log(hLength);
    }

    // Update is called once per frame
    void Update() {

        float scroll = 0;

        //if (GameControl.instance.IsPlaying) {
        //    scroll += scrollspeed;
        //}

        rb2d.velocity = new Vector2(scrollspeed, 0);


        if (transform.position.x < -hLength-10) {
            Reposition();
        }
    }

    private void Reposition() {

        Vector2 groundOffset = new Vector2(hLength * 3f, 0);
        transform.position = (Vector2)transform.position + groundOffset;

    }


}
