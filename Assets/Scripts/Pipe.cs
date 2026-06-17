using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        this.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
