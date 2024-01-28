using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAndBullets : MonoBehaviour
{
    public float range = 100f;
    public int damageAmount = 20;
    private GunPlayerMovement GPMScript;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public float ClipLength = 1f;

    // public ParticleSystem muzzleFlash;
    // public GameObject impactEffect;

    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineAmmo = 30;

    public float reloadTime = 2f;
    public float impactforce = 30f;
    [Range(0,7f)]public float recoilamountY;
    [Range(0,4f)]public float recoilamountX;

    public float currentrecoilXpos;
    public float currentrecoilYpos;
    public bool isReloading;
    private bool isHavingGoldenKey = false;
    private bool isHavingSilverKey = false;

    public Animator animator1;
    public Animator animator2;
    public GameObject armature;
    public Camera fpsCam;
    public GameObject muzzleFlash;
    public Transform muzzleFlashposition;
    public GameObject impactEffect;
    public GameObject audioClip;
    public GameObject Chest_Lid;
    public GameObject Chest_Lid2;
    public GameObject Chest_Lid3;
    public GameObject Chest_Lid4;
    public GameObject Scroll_Open;
    public GameObject Message1;
    public GameObject Message2;
    public GameObject Message3;
    public GameObject pLayer;
    public GameObject FindKeyMessage;
    public GameObject FindKeyMessage2;
    public GameObject keyimage;
    public GameObject Silverkeyimage;
    public GameObject keysilver;
    public GameObject keysilverClone;
    public GameObject portalin;
    public GameObject portalout;
    // [SerializeField]
    public RandomLocationKey LocationScript;

    void Start()
    {
        audioClip.SetActive(false);
        currentAmmo = maxAmmo;
        // keysilverClone = GameObject.Find("Key_Silver(Clone)");
    }
    void Awake(){
        animator1 = armature.GetComponent<Animator>();
        GPMScript = pLayer.GetComponent<GunPlayerMovement>();
    }
    void OnTriggerEnter(Collider other) {
            Debug.Log("Hello");
         if(other.CompareTag("Portal"))
            Debug.Log("Hell");

            transform.position = portalout.transform.position;
 
     }
    // public void recoilMath(){
    //     currentrecoilXpos = ((Random.value - 0.5f)/2) * recoilamountX;//actually y rotation of player
    //     currentrecoilYpos = ((Random.value - 0.5f)/2) * recoilamountY;
        
    //     GPMScript.cameraHolder.Rotate(-currentrecoilYpos,0,0);
    //     GPMScript.currentRotation = GPMScript.cameraHolder.localEulerAngles;//defining
    //     if (GPMScript.currentRotation.x > 180) GPMScript.currentRotation.x -= 360;
    //     GPMScript.currentRotation.x = Mathf.Clamp(GPMScript.currentRotation.x, GPMScript.upLimit, GPMScript.downLimit);
    //     GPMScript.cameraHolder.localRotation = Quaternion.Euler(GPMScript.currentRotation);//rotation relative to parent

    // }
    void Update(){
        // float a = Input.GetButtonDown("Fire1");
        // bool isShooting = a == 1;
        // if (GameObject.FindWithTag("SilverKey") != null && GameObject.FindWithTag("SilverKey") !=keysilver){
            // keysilverClone = GameObject.Find("Key_Silver(Clone)");
        // }
        keysilverClone = LocationScript.SilverKeyClone;

         if ( Input.GetButton("Fire1") && Time.time/*current time*/ >= nextTimeToFire )
        {//GetButtor to Hold down to automatically fire
        RaycastHit hit1;
            if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit1,range)){

            if(hit1.transform.gameObject.CompareTag("GoldKey")){
                    Destroy(hit1.transform.gameObject);
                    isHavingGoldenKey = true;
            }
            else if(hit1.transform.gameObject.CompareTag("SilverKey")){
                    Destroy(hit1.transform.gameObject);
                    isHavingSilverKey = true;

            }
            else{
            nextTimeToFire = Time.time + 1f/fireRate;
            StartCoroutine(Shoot());
            animator1.SetBool("isShooting",true);  
            }
            }
            

        }
        if (!Input.GetButtonDown("Fire1") && Time.time/*current time*/ >= nextTimeToFire)
        {
            // Shoot();
            animator1.SetBool("isShooting",false);            
        }
        if(Input.GetKey(KeyCode.F)){
            Message1.SetActive(false);
            Message2.SetActive(false);
            Message3.SetActive(false);
        }
        // if(pLayer.transform.position == portalin.transform.position){
        //     Debug.Log("hit");
        //    pLayer.transform.position = portalout.transform.position;
        // }
    }
    IEnumerator Shoot(){
        RaycastHit hit;
        GameObject Flash = Instantiate(muzzleFlash, muzzleFlashposition);
        Destroy(Flash,0.1f);
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)){
            Debug.Log(hit.transform.name);



            Target target = hit.transform.GetComponent<Target>();
            if(target!=null){
                target.TakeDamage(damageAmount);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }



            if(hit.transform.name == "Chest_Lid"){
                animator2 = Chest_Lid.GetComponent<Animator>();
                animator2.SetBool("IsOpened",true);
                yield return new WaitForSeconds(5);   
                animator2.SetBool("IsOpened",false);
            }
            if(hit.transform.name == "Chest_Lid3"&& isHavingSilverKey == false){
                FindKeyMessage2.SetActive(true);
                yield return new WaitForSeconds(3);
                FindKeyMessage2.SetActive(false);
            }
            if(hit.transform.name == "Chest_Lid3"&& isHavingSilverKey == true){
                animator2 = Chest_Lid3.GetComponent<Animator>();
                animator2.SetBool("IsOpened",true);
                yield return new WaitForSeconds(5);   
                animator2.SetBool("IsOpened",false);
            }
            if(hit.transform.name == "Chest_Lid4"){
                animator2 = Chest_Lid4.GetComponent<Animator>();
                animator2.SetBool("IsOpened",true);
                yield return new WaitForSeconds(5);   
                animator2.SetBool("IsOpened",false);
            }
            if(hit.transform.name == "Chest_Lid2" && isHavingGoldenKey == false){
                //screen say Find a golden key
                FindKeyMessage.SetActive(true);
                yield return new WaitForSeconds(3);
                FindKeyMessage.SetActive(false);
            }

            if(hit.transform.name == "Chest_Lid2" && isHavingGoldenKey == true){
                animator2 = Chest_Lid2.GetComponent<Animator>();
                animator2.SetBool("IsOpened",true);
                yield return new WaitForSeconds(5);   
                animator2.SetBool("IsOpened",false);
                keysilverClone.SetActive(true);
            }

            if(hit.transform.name == "Scroll_Open"){
            Debug.Log("hit");
            Message1.SetActive(true);
            }
            if(hit.transform.name == "Scroll_Open (1)"){
            Debug.Log("hit");
            Message2.SetActive(true);
            }
            if(hit.transform.name == "Scroll_Open (2)"){
            Debug.Log("hit");
            Message3.SetActive(true);
            }
            
            if(isHavingGoldenKey == true){
                //tell UI to show it
            keyimage.SetActive(true);

            }
            if(isHavingSilverKey == true){
                //tell UI to show it
            Silverkeyimage.SetActive(true);

            }



            GameObject xyz = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(xyz,2f);
            // recoilMath();
        }
        audioClip.SetActive(false);
        yield return new WaitForSeconds(ClipLength);   
        audioClip.SetActive(false);
    }
    private void OnEnable()
    {
        // isReloading = false;
        // animator1.SetBool("isReloading", false);
    }

}
