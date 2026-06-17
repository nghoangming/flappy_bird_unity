using UnityEngine;

public class CreatePipe : MonoBehaviour
{
    public GameObject pipePrefabs;
    private float countdown;
    public float timeDuration;
    public bool enableCreatePipe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = timeDuration;
        enableCreatePipe = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enableCreatePipe == true)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                Instantiate(pipePrefabs, new Vector3(10, Random.Range(-7.5f, -3.5f),0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
        
    }
}
