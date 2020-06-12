using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    [SerializeField]
    private float _gravityModifier;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private CharacterController _controller;
    private Vector3 _moveInput;
    [SerializeField]
    private Transform _camTransform;
    [SerializeField]
    private float _mouseSens;
    [SerializeField]
    private float _jumpPower;
    private bool _canJump;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _setGround;
    [SerializeField]
    private float _runSpeed;
    [SerializeField]
    private Animator anim;
  //  [SerializeField]
  //  private GameObject _bullet;
    [SerializeField]
    private Transform _firePoint;

    [SerializeField]
    private Transform _firePoint2;
    //  [SerializeField]
    //  private float _fireRate = 0.1f;
    //  [SerializeField]
    //  private float _fireCounter;
    [SerializeField]
    private Transform _shellEjectPoint;
  //  [SerializeField]
  //  private GameObject _bulletShell;
    
    public Gun _activeGun;

    public WeaponRecoil _recoil;

    public List<Gun> allGuns = new List<Gun>();
    public List<Gun> unlockableGuns = new List<Gun>();
    public int currentGun;

    private float _jumpPadAmount;
    private bool _jumpPadJump;

  //  private bool _onCeiling = false;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        currentGun--;
        SwitchWeapon();
    }

 /*   void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Ceiling")
        {
            _moveInput.y *= 0;
           // _onCeiling = true;

        }
    } */


    void Update()
    {

        // _fireCounter -= Time.deltaTime;
       
        if ((_controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            if (_moveInput.y > 0)
            {
                _moveInput.y = _moveInput.y * -0.4f;
            }
            
        }

        Movement();

        Camera();

        if (Input.GetMouseButtonDown(0) && _activeGun.fireCounter <= 0)
        {
            
            
                RaycastHit hit;
                if (Physics.Raycast(_camTransform.position, _camTransform.forward, out hit, 50f))
                {
                    if (Vector3.Distance(_camTransform.position, hit.point) > 1f)
                    {
                        _firePoint.LookAt(hit.point);
                        _firePoint2.LookAt(hit.point);
                    }
                }
                else
                {
                    _firePoint.LookAt(_camTransform.position + (_camTransform.forward * 30f));
                    _firePoint2.LookAt(_camTransform.position + (_camTransform.forward * 30f));
                }

                FireShot();
            
        }

        if (Input.GetMouseButton(0) && _activeGun.canAutoFire)
        {
            if (_activeGun.fireCounter <= 0)
            {
                FireShot();
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon();
        }
        
        anim.SetFloat("moveSpeed", _moveInput.magnitude);
        anim.SetBool("grounded", _canJump);    
    }

    private void Movement()
    {
        //store current y vel
        float yStore = _moveInput.y;

        Vector3 verticalMovement = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalMovement = transform.right * Input.GetAxis("Horizontal");

        _moveInput = verticalMovement + horizontalMovement;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveInput = _moveInput * _runSpeed;
            _moveInput = Vector3.ClampMagnitude(_moveInput, 12f);
        }
        else
        {
            _moveInput = _moveInput * _moveSpeed;
            _moveInput = Vector3.ClampMagnitude(_moveInput, 8f);
        }

        _moveInput.y = yStore;

        _moveInput.y += Physics.gravity.y * _gravityModifier * Time.deltaTime;

        if (_controller.isGrounded)
        {
            _moveInput.y = Physics.gravity.y * _gravityModifier * Time.deltaTime;
        }

        _canJump = Physics.OverlapSphere(_groundCheck.position, 0.25f, _setGround).Length > 0;

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _moveInput.y += _jumpPower;
        }

        if(_jumpPadJump)
        {
            _jumpPadJump = false;
            _moveInput.y = _jumpPadAmount;            
        }
        
        
        //apply movement
        _controller.Move(_moveInput * Time.deltaTime);
    }

    private void Camera()
    {        
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSens;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        _camTransform.rotation = Quaternion.Euler(_camTransform.rotation.eulerAngles.x - mouseInput.y, _camTransform.rotation.eulerAngles.y, _camTransform.rotation.eulerAngles.z);
    }


    public void FireShot()
    {
         if (_activeGun.currentAmmo > 0)
         {
            _recoil.Recoil();
            
            _activeGun.currentAmmo--;

            Instantiate(_activeGun.muzzleFlash, _firePoint.position, _firePoint.rotation);

            Instantiate(_activeGun.bullet, _firePoint.position, _firePoint.rotation);

            Instantiate(_activeGun.bulletShell, _shellEjectPoint.position, _shellEjectPoint.rotation);

            _activeGun.fireCounter = _activeGun.fireRate;

            UIController.instance.ammoText.text = "" + _activeGun.currentAmmo;

            if(_activeGun.firePoint2 != null)
            {
                Instantiate(_activeGun.muzzleFlash, _firePoint2.position, _firePoint2.rotation);
                Instantiate(_activeGun.bullet, _firePoint2.position, _firePoint2.rotation);
            }

         }

        // else play sound

    }

    public void SwitchWeapon()
    {
        _activeGun.gameObject.SetActive(false);
       
        currentGun++;
        if(currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        _activeGun = allGuns[currentGun];
        _activeGun.gameObject.SetActive(true);
       
        UIController.instance.ammoText.text = "" + _activeGun.currentAmmo;

        _firePoint.position = _activeGun.firePoint.position;

        if(_activeGun.firePoint2 != null)
        {
            _firePoint2.position = _activeGun.firePoint2.position;
        }
    }

    public void AddGun(string gunToAdd)
    {
        bool gunUnlocked = false;

        if(unlockableGuns.Count > 0)
        {
            for(int i = 0; i < unlockableGuns.Count; i++)
            {
                if(unlockableGuns[i].gunName == gunToAdd)
                {
                    gunUnlocked = true;

                    allGuns.Add(unlockableGuns[i]);
                    unlockableGuns.RemoveAt(i);

                    i = unlockableGuns.Count;
                }
            }
        }
    
        if(gunUnlocked)
        {
            currentGun = allGuns.Count - 2;
            SwitchWeapon();
        }
    
    }

    public void JumpPad(float jumpForce)
    {
        _jumpPadAmount = jumpForce;
        _jumpPadJump = true;
    }

}
