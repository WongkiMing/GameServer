using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject Shootdir;
    [SerializeField]
    GameObject projectile;

    float inputSpeed = 1f;
    float speed = 0f;
    float rotz = 90f;

    public bool islocal = true;

    Vector3 oldRotation;
    Vector3 CurrentRotation;
    // Start is called before the first frame update
    void Start()
    {
        oldRotation = Shootdir.transform.eulerAngles;
        CurrentRotation = oldRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!islocal)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotz += inputSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotz -= inputSpeed;
        }
        else
        {
            speed = 0f;
        }
        rotz = Mathf.Clamp(rotz, 0f, 90f);
        Shootdir.transform.eulerAngles = new Vector3(0f, 0f, rotz);

        CurrentRotation = Shootdir.transform.eulerAngles;

        if(CurrentRotation != oldRotation)
        {
            //Network part
            oldRotation = CurrentRotation;
            Debug.Log(oldRotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectilePrefab = Instantiate(projectile, transform.position, Quaternion.identity);
        projectilePrefab.GetComponent<Rigidbody>().AddForce(Shootdir.transform.up * 20f, ForceMode.Impulse);
    }

}
