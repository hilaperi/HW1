using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private float _speed;
    private float _angularSpeed=1f;
    private float _rotationAngle;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 0f;
        _rotationAngle = 0f;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))
            _speed += 0.05f;
        else if(Input.GetKey(KeyCode.S))
                _speed -= 0.05f;


        _rotationAngle += mouse_x * _angularSpeed * Time.deltaTime;
        transform.Rotate(0, _rotationAngle, 0);

        //transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        _characterController.Move(direction);


    }
}
