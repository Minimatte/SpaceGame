using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {

    public TrailRenderer trail2;
    // Use this for initialization
    void Start()
    {
        trail2.sortingLayerName = "Default";
        trail2.sortingOrder = 2;

    }
}
