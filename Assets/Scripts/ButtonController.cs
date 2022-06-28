using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private Vector3 spawnPos;
    private Rigidbody rb;
    public Text countText;
    private int count;
    public float speed=5;
    private void Start()
    {
        spawnPos = transform.position;
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
    }
    public void MoveUp()
    {
        transform.Translate(0f, 0f, -8f);
    }
    public void MoveDown()
    {
        transform.Translate(0f, 0f, 8f);
    }
    public void MoveLeft()
    {
        transform.Translate(8f, 0f, 0f);
    }
    public void MoveRight()
    {
        transform.Translate(-8f, 0f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        if (other.gameObject.CompareTag("Finish1"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(1);
        }
        //if (other.gameObject.CompareTag("Respawn"))
        //{
        //    transform.position = spawnPos;
        //}
    }
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
