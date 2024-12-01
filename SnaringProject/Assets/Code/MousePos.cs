using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    Vector2 MousePosition;
    Camera Camera;
    public Grid Grid;

    // Start is called before the first frame update
    private void Start()
    {
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);

            Debug.Log(Grid.WorldToCell(MousePosition));
        }
    }
}
