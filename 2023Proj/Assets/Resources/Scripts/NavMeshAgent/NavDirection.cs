using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDirection : MonoBehaviour
{
    public Player3D Player3Ddir;
    public Swpan Swpandir;

    void Start()
    {
        Player3Ddir = FindObjectOfType<Player3D>();
        Swpandir = FindObjectOfType<Swpan>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Player3Ddir.transform.position - Swpandir.Vector3ranchilDir();
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = rotation;
    }
}
