using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Rigidbody rb;
    public Text countText;
    private int count;
    //private Rigidbody rb;
    public float speed=5;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
    }
    public void MoveUp()
    {
        transform.Translate(0f, 0f, -8f);
        //Vector3 movement = new Vector3(0, 0, 8);
        //rb.AddForce(movement * speed);

        //rb.constraints= RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    public void MoveDown()
    {
        transform.Translate(0f, 0f, 8f);
        //Vector3 movement = new Vector3(0f, 0f, 16f);
        //rb.AddForce(movement * speed);
    }
    public void MoveLeft()
    {
        transform.Translate(8f, 0f, 0f);
        //Vector3 movement = new Vector3(-8f, 0f, 0f);
        //rb.AddForce(movement * speed);
    }
    public void MoveRight()
    {
        transform.Translate(-8f, 0f, 0f);
        //Vector3 movement = new Vector3(-8f, 0f, 0f);
        //rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(1);
        }
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
