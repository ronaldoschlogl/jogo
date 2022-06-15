using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TPS : MonoBehaviour, IKillable
{
    public GameObject aimCamera;
    public GameObject bulletPrefab;
    public float rotateSpeed = 15;
    
    public Transform debugTransform;
    public Transform bulletSpawn;

    //public ParticleSystem Flash;
    public AudioClip SomTiro;

    StarterAssetsInputs input;
    ThirdPersonController tpc;
    Camera mainCamera;
    Animator animator; 
    [Range(0, 1)] public float ShootAudioVolume = 0.5f;


    public ControlaInterface scriptControlaInterface;
    public GameObject GameOver;
    public AudioClip SomDano;

    public Status statusPlayer;

    void Start()
    {
        statusPlayer = GetComponent<Status>();
        tpc = GetComponent<ThirdPersonController>();
        animator = GetComponent<Animator>();
        input = GetComponent<StarterAssetsInputs>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(statusPlayer.Vida > 0)
        {
            Mirar();
        }
        else if(statusPlayer.Vida <= 0)
        {
            if(input.jump)
            {
                scriptControlaInterface.Reiniciar();
            }
        }
    }

    void Mirar()
    {
        Vector3 aimPosition = Vector3.zero;
        Vector2 screenCenterPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = mainCamera.ScreenPointToRay(screenCenterPos);

        if (Physics.Raycast(ray, out RaycastHit hit, statusPlayer.aimMaxDistance))
        {
            debugTransform.position = hit.point;
            aimPosition = hit.point;
        }
        else
        {
            debugTransform.position = ray.origin + ray.direction * statusPlayer.aimMaxDistance;
            aimPosition = ray.origin + ray.direction * statusPlayer.aimMaxDistance;
        }

        if (input.aim && (statusPlayer.Vida > 0))
        {
            animator.SetLayerWeight(1, 1);
            tpc.SetRotateOnMove(false);
            aimCamera.SetActive(true);
            float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), Time.deltaTime * rotateSpeed);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
            aimCamera.SetActive(false);
            tpc.SetRotateOnMove(true);
        }

        if (input.shoot && input.aim && (statusPlayer.Vida > 0))
        {
            input.shoot = false;
            Vector3 bulletDirection = (aimPosition - bulletSpawn.position).normalized;
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.LookRotation(bulletDirection));

            AudioSource.PlayClipAtPoint(SomTiro, bulletSpawn.position, ShootAudioVolume);
            ControlaAudio.instancia.PlayOneShot(SomTiro);
        }
    }

    public void TomarDano(int dano)
    {
        statusPlayer.Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDano);

        if (statusPlayer.Vida <= 0)
        {
            Morrer();
        }

    }

    public void Morrer()
    {
        scriptControlaInterface.GameOver();
    }
}
