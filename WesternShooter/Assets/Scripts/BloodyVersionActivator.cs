using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* > If the user touches the screen for more than 2 seconds, the bloody version is enabled */
public class BloodyVersionActivator : MonoBehaviour{
    public bool isBloodVersionActive = false;
    float startTime;
    bool touchDown = false;


    private void Update(){
        if (isBloodVersionActive == false){
            isBloodVersionActive = EnableBloodyVersion();
        }
    }


    private bool EnableBloodyVersion(){
        bool isEnable = false;
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began){
                startTime = Time.time;
                touchDown = true;
            }
            else if (touchDown){
                if (Time.time - startTime > 2.0f){
                    isEnable = true;
                }
            }
        }
        else{
            touchDown = false;
        }

        return isEnable;
    }
}