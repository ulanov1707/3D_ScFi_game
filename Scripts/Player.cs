using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 2f;
    private float _gravity = 9.18f;
    [SerializeField]
    private GameObject _MuzzleFlash;
    [SerializeField]
    private GameObject _HitMarker;
    [SerializeField]
    private AudioSource _ShootSound;    
    private int _MaxAmmo = 50;
    [SerializeField]
    private int _CurrentAmmo;
    private bool _isReloading = false;
    [SerializeField]
    private UI_Manager _UI_Manager;
    [SerializeField]
    GameObject _Weapon;

    public bool _canShoot = false;
    public bool HasCoin = false;
   

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_MuzzleFlash == null) { Debug.Log("NO Muzzle Flash assigned!"); }
        if (_controller == null) { Debug.Log("Controller isnt set!"); }
        if (_HitMarker == null) { Debug.Log("Hit marker not assigned! "); }
        if (_ShootSound == null) { Debug.Log("NO Shoot sound ASSIGNED"); }
        if (_UI_Manager == null) { Debug.Log("No Ammo Text Assigne"); }
        if (_Weapon == null) { Debug.Log("Weapon isnt SET"); }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _MuzzleFlash.SetActive(false);

        _CurrentAmmo = _MaxAmmo;
        _UI_Manager.UpdateAmmoText(_CurrentAmmo);

        _Weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && _CurrentAmmo > 0)//0 is an index of leftMouse Button
        {
            if(_canShoot == true )
                Shoot();
            
        }else 
        {
            _MuzzleFlash.SetActive(false);
            _ShootSound.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && (_isReloading == false))
        {
        
            _isReloading = true;
            StartCoroutine(Reload());


        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.lockState= CursorLockMode.None;
            Cursor.visible = true;
        }

      
        CalculateMovement();
       
    }


    void CalculateMovement() 
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;//Applying custom gravity
        velocity = transform.transform.TransformDirection(velocity);// Converts from localspace to global space
        _controller.Move(velocity * Time.deltaTime);

    }

    void Shoot() 
    {
        _MuzzleFlash.SetActive(true);//activates bullets VFX
        _CurrentAmmo--;
        _UI_Manager.UpdateAmmoText(_CurrentAmmo);

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//gives center of the screen (half of width , half of height)
        RaycastHit HitInfo;

        if (_ShootSound.isPlaying == false)
        {
            _ShootSound.Play();
        }

      

        if (Physics.Raycast(rayOrigin, out HitInfo)) //check is we hit something
        {
            //spawn IMPACT VFX 
            GameObject HitMarkerTemp = Instantiate(_HitMarker, HitInfo.point, Quaternion.LookRotation(HitInfo.normal)) as GameObject/*Typcasting ex: (float) 1 + 2(int)*/;//Hitinfo.point is impact point
            Destroy(HitMarkerTemp, 1f);

            DestructibleBox _box = HitInfo.transform.GetComponent<DestructibleBox>();
            if (_box != null)
            {
                _box.SwapToDestructible();
            }
        }

       
    }

    IEnumerator Reload() {
        
        
         yield return new WaitForSeconds(1.7f);
        _CurrentAmmo = _MaxAmmo;
        _UI_Manager.UpdateAmmoText(_CurrentAmmo);
        _isReloading = false;
        
    }

    public void SetWeaponActive() 
    {
        _Weapon.SetActive(true);
    }

  
}
