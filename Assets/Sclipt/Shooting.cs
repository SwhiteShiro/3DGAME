using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float speed = 4000;
    [SerializeField] private float smooth = 1.25f;


    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Space))    //�X�y�[�X�Œe�۔���
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            bullets.tag = "Bullet";
            Vector3 force;    
            force = this.gameObject.transform.forward * speed;

            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = muzzle.position;

            Destroy(bullets, 2.0f);
            
        }

        
        float x = Input.GetAxis("Vertical");        //up�ŏ�ցAdown�ŉ��֎��_��������
        float y = Input.GetAxis("Horizontal");      //left�ō��Aright�ŉE�֎��_��������

        if (x != 0 || y != 0)
        {
            x = x * smooth;
            y = y * smooth;

            Quaternion rotation = this.transform.rotation;
            Vector3 rotationAngles = rotation.eulerAngles;

            rotationAngles.x = rotationAngles.x - x;
            rotationAngles.y = rotationAngles.y + y;

            rotation = Quaternion.Euler(rotationAngles);
            this.transform.rotation = rotation;
        }
    }
}
