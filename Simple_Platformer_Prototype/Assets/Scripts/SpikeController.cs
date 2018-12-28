using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{

    #region Variables
    public float speed = 200.0f;
    #endregion

    private void Update()
    {
        this.transform.localEulerAngles = new Vector3(
            this.transform.localEulerAngles.x,
            this.transform.localEulerAngles.y,
            this.transform.localEulerAngles.z + speed * Time.deltaTime);
    }

}// main class
