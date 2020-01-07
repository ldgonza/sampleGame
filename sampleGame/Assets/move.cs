using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Timer timer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.timer = new Timer();
    }

    // Update is called once per frame
    void Update()
    {
        int frames = this.timer.Update(Time.deltaTime);
        for(int i = 0; i < frames; i++)
        {
            var transform = GetComponent<Transform>();
            var pos = transform.position;
            pos.x += speed;
            pos.y += speed;
            transform.position = pos;
        }
    }
}
