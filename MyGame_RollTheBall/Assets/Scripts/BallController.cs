using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public float speed;
    public int count;
    public Text countText;

	// Use this for initialization
	void Start () {
        count = 0;
        setCountText();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        Vector3 currentPos = movement * speed * Time.deltaTime;
        string message = "FixedUpdate x = " + currentPos.x + ", y = " + currentPos.y + ", z = " + currentPos.z + ", speed = " + speed + " deltaTime = " + Time.deltaTime;
        Debug.Log(message);
        GetComponent<Rigidbody>().AddForce(currentPos);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count : " + count;
    }
}
