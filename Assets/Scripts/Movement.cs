using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float velocity = 10f;
    [SerializeField] private float jumpH = 4f;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(-velocity * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
           rb2D.AddForce(new Vector2(0, jumpH), ForceMode2D.Impulse);

    }
}
