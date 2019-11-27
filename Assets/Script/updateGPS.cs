using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateGPS : MonoBehaviour
{
    public Text coordinate;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        coordinate.text = "lat:"+GPS.Instance.latitude.ToString() +", long:"+ GPS.Instance.longitude.ToString()+ ", altitude:"+ GPS.Instance.altitude.ToString()+", horacur:"+ GPS.Instance.horizontalAccuracy.ToString();
    }
}
