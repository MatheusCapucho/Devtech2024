using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aniamtion_controller : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int quadrant = _cursor.GetComponent<CursorMovement>().GetQuadrant();
        if (quadrant == 1) {
            GetComponent<SpriteRenderer>().flipX = true;
        }else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
