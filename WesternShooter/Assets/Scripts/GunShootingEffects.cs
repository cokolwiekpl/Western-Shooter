using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingEffects : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioClip gunNoise;
    [SerializeField] private GameObject muzzleflash;
    [SerializeField] bool isShoted = false;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (isShoted == false)
            {
                /* It's triggering the animation. */
                anim.SetTrigger("Shoot");
                /* It's turning on the muzzleflash gameobject. */
                muzzleflash.SetActive(true);

                /* It's rotating the muzzleflash gameobject. */
                muzzleflash.transform.Rotate(new Vector3(Random.Range(0f, 259f), 0f, 0f));

                /* It's turning off the muzzleflash gameobject after 0.11 seconds. */
                StartCoroutine(RemoveAfterSeconds(0.11f, muzzleflash));


                /* It's playing the sound. */
                SoundManager.Instance.PlaySfxGun(gunNoise);


                isShoted = true;
                /* It's waiting for 0.5 seconds and then it's turning the `isShoted` boolean to false. */
                StartCoroutine(isShotedToFalse(0.5f));
            }
        }
    }

    //Timers
    IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    IEnumerator isShotedToFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isShoted = false;
    }
}