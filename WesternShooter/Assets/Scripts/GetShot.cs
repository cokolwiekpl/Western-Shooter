using System.Collections.Generic;
using UnityEngine;

public class GetShot : MonoBehaviour{
    [SerializeField] bool isBreakable;
    [SerializeField] bool isSoundPlayed = false;
    [SerializeField] bool isPointsAdded = false;
    [SerializeField] private List<GameObject> chunks;
    [SerializeField] private AudioClip damagedSound;
    [SerializeField] private GameObject particlesDeath;
    [SerializeField] private float goUpBy;
    [SerializeField] private float knockback;
    [SerializeField] private bool isKillable;

    public int points;
    private bool isDead;
    private ActivateRagdoll rag;
    public GameObject impactEffect;


    void Update(){
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)){
            if (PauseMenu.isGamePaused == false){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)){
                    if (hit.transform == gameObject.transform){
                        /* It's adding force to the object, which was shot. */
                        try{
                            var rb = gameObject.GetComponent<Rigidbody>();
                            rb.AddForce(-hit.normal * knockback, ForceMode.Impulse);
                        }
                        catch{
                            //Debug.Log("Object shot doesn't have RB - this is fine.");
                        }

                        /* It's checking if the bloody version is active. If it is, it's spawning blood splats. If it's not, it's spawning
                        particlesDeath. */
                        GameObject bloodyVersionManager = GameObject.Find("BloodyVersionManager");
                        BloodyVersionActivator bloodyVersionActivator = bloodyVersionManager.GetComponent<BloodyVersionActivator>();
                        bool isBloodyVersion = bloodyVersionActivator.isBloodVersionActive;
                        if (isBloodyVersion){
                            try{
                                GameObject breakingParticleEmitter =
                                    Instantiate(particlesDeath, hit.point, Quaternion.LookRotation(hit.normal));
                                Destroy(breakingParticleEmitter, 1f);
                            }
                            catch{ }
                        }
                        else{
                            if (particlesDeath.ToString() != "BloodSplat_FX (UnityEngine.GameObject)"){
                                try{
                                    GameObject breakingParticleEmitter =
                                        Instantiate(particlesDeath, hit.point, Quaternion.LookRotation(hit.normal));
                                    Destroy(breakingParticleEmitter, 1f);
                                }
                                catch{ }
                            }
                        }

                        BreakObject();
                    }
                }
            }
        }
    }


    public virtual void BreakObject(){
        try{
            /* It's spawning chunks (debree, body parts, broken glass, etc.) */
            foreach (GameObject piece in chunks){
                //create the objects in world space
                var brokenPiece = Instantiate(piece, this.transform.position, Quaternion.identity);
                //assign some random force to each of the newly created objects to make them fly in a random direction
                brokenPiece.GetComponent<Rigidbody>()
                    .AddForce(new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f)),
                        ForceMode.Impulse);
                Destroy(brokenPiece, 2f);
            }
        }
        catch{
            Debug.Log("Shot at object, which doesn't break into pieces - this is fine.");
        }


        //plays sound after being shot down
        if (!isDead){
            try{
                if (isSoundPlayed == false){
                    SoundManager.Instance.PlaySfxEnemy(damagedSound);
                    isSoundPlayed = true;
                }
            }
            catch{ }
        }

        //jump
        if (goUpBy > 0){
            var rb = gameObject.GetComponent<Rigidbody>();
            //up
            rb.AddForce(new Vector3(0f, goUpBy, 0f), ForceMode.Impulse);
            //rotate
            rb.AddTorque(new Vector3(Random.Range(0.4f, 0.75f), Random.Range(0.4f, 0.75f), Random.Range(0.4f, 0.75f)));
        }

        //ragdoll
        try{
            transform.parent.parent.parent.parent.parent.parent.parent.gameObject.tag = "Dead";
        }
        catch{
            Debug.Log("Object Shot Not ragdollable - this is fine.");
        }

        //remove outline after dead
        try{
            if (transform.parent.parent.parent.parent.parent.parent.parent.gameObject.CompareTag("Dead")){
                transform.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<Outline>().enabled =
                    false;
            }
        }
        catch{ }


        /* It's a hack to prevent adding points multiple times. */
        if (isPointsAdded == false){
            //add points to point manager
            ScoreCounting.Instance.AddScore(points);
            isPointsAdded = true;
        }


        /* It's checking if the object is breakable. If it is, it destroys it. */
        if (isBreakable){
            Destroy(gameObject);
        }

        if (isKillable){
            isDead = true;
        }
    }


    private void Awake(){
        try{
            rag = transform.root.GetComponent<ActivateRagdoll>();
        }
        catch{ }
    }
}