using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodActivator : MonoBehaviour
{
    public GameObject blood;

    // Update is called once per frame
    void Update()
    {

        if (BloodyVersionActivator.isBloodVersionActive == true)
        {
            blood.SetActive(true);
        }
        else
        {
            blood.SetActive(false);
        }
    }
}
