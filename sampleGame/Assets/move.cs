using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Timer.Timer timer;
    public float speed;

    private State.State state;

    void Start()
    {
        this.state = new State.TimedState("WAITING");
        this.timer = new Timer.Timer();
    }

    void Update()
    {
        int frames = this.timer.Update(Time.deltaTime);
        for(int i = 0; i < frames; i++)
        {
            this.state.Update(1);
            var transform = GetComponent<Transform>();
            var pos = transform.position;
            pos.x += speed;
            pos.y += speed;
            transform.position = pos;
        }
    }
}
