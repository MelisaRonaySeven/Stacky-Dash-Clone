using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dashes")
        {
            other.gameObject.tag = "Normal";
            PlayerController.Instance.TakeDashes(other.gameObject);

            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.AddComponent<StackScript>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

            Destroy(this);
        }
        else if (other.gameObject.tag == "Empty")
        {
            PlayerController.Instance.RemoveDashes(other.gameObject);
            Destroy(this);
        }
        else if (other.gameObject.tag == "EndingPoint")
        {
            PlayerController.Instance.EndingPoint();
            Destroy(this);
        }
    }
}
