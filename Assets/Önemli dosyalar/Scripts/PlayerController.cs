using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody  rb;
    private int count;
    public float moveSpeed = 10;
    public TextMeshProUGUI CountTEXT;
    public GameObject winTextObject;

    public float xInput;
    public float yInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

      void SetCountText()
    {
        CountTEXT.text = "Count:" + count.ToString();
        if(count >= 20)
        {
           winTextObject.SetActive(true); 
        }
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       

    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    
    private void Move()
    {
        rb.AddForce(new Vector3(xInput,0f,yInput) * moveSpeed);
    }
  
}






