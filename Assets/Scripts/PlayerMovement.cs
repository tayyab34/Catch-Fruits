using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public int score = 0;
    public Rigidbody achievement;
    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -7.6f)
        {
            transform.position = new Vector3(-7.6f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 14)
        {
            transform.position = new Vector3(14, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fruit"))
        {
            Destroy(other.gameObject);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 1, transform.localScale.z);
            score += 10;
            Score.text = "Score:" + score;
        }
        else if (other.CompareTag("achievement"))
        {
            transform.parent = achievement.transform;
        }
        
    }
}
