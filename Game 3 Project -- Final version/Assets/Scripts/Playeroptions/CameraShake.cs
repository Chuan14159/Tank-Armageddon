using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{


    public bool Shaking;
    private float ShakeDecay;
    private float ShakeIntensity;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;

    void Start()
    {
        Shaking = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (ShakeIntensity > 0)
        {
            //transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                      OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f);

            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x+30, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z);
        }

    }


    public void DoShake()
    {
        //OriginalPos = transform.position;
        OriginalRot = transform.rotation;
        float shake = 0.01f;
        if (GameDecider.health > 0)
        {
            shake = (float)(0.7 / GameDecider.health);
        }
        ShakeIntensity = shake;
        //if (GameDecider.health == 2)
        //{
        //    ShakeIntensity = 0.2f;

            
        //}
        //else if(GameDecider.health == 1)
        //{
        //    ShakeIntensity = 1.0f;
        //}
        ShakeDecay = 0.02f;
        Shaking = true;

    }


}