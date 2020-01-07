using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacion : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private Sprite[] frameArray2;
    [SerializeField] private int[] duracion;
  
    private void Start()
    {
       
    }
    private void Update()
    {
        var state = gameObject.GetComponent<Move>().state;
        int frame = 0;
        int total = state.CurrentFrame;

        for (int i = 0; i< duracion.Length; i++)
        {
            if (total < duracion[i])
            {
                frame = i;
                break;
            }
            total -= duracion[i];

        }
        var animacion = frameArray;
        if(state.Name == "B")
        {
            animacion = frameArray2;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = animacion[frame];

    }
}
