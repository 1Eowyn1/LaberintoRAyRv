using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{

    private CharacterController userCharacter;
    private Transform cameraTransform;

    public Vector3 userDirection;
    public float userSpeed;

    public Transform bulletStart;
    public GameObject bullet;
    public float bulletForce;

    void Start()
    {
        userCharacter = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector2 userControl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTransform.eulerAngles.y;
        Vector3 camerarotation = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTransform.forward;
        userDirection = (camerarotation * Input.GetAxis("Horizontal") + cameraTransform.forward * Input.GetAxis("Vertical")).normalized;

        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, bulletStart.transform.position, bulletStart.rotation);
            Rigidbody bulletforce = newBullet.GetComponent<Rigidbody>();
            bulletforce.AddForce(bulletStart.forward * Time.deltaTime * bulletForce, ForceMode.Impulse);
        }
    }
}