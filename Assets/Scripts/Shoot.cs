using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectilePrefab = Instantiate(projectile, transform.position, Quaternion.identity);
            projectilePrefab.GetComponent<Rigidbody>().AddForce(transform.up * 20f, ForceMode.Impulse);
        }
    }
}
