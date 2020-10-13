using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour {

    public float speed = 3;
    public string player = "";

    private void Update() {
        transform.position += 
            speed * 
            Time.deltaTime * 
            new Vector3(InputManager.Instance.GetAxis(InputManager.Instance.horizontal + player), 0, InputManager.Instance.GetAxis(InputManager.Instance.vertical + player));
    }

}
