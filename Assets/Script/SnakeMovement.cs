using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 direction;
    bool spawn = false;
    public bool Spawn
    {
        get { return spawn; }
        set { spawn = value; }
    }
    public Transform segment;
    [SerializeField] List<Transform> segments;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        StartCoroutine(counting(0.5f));
        segments.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
    }
    void FixedUpdate()
    {
        
    }
    IEnumerator counting(float countSec)
    {
        float counter = 0;
        while(true)
        {
            yield return new WaitForSeconds(countSec - counter);
            for(int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }
            this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y
            );
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("fruit"))
        {
            Destroy(other.gameObject);
            spawn = true;
            Grow();
        }
    }
    void Grow()
    {
        Transform currentSeg = Instantiate(segment);
        currentSeg.position = segments[segments.Count - 1].position;
        segments.Add(currentSeg);
    }
}
