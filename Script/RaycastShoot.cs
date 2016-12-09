using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour
{
    public int weaponDamage = 1;
    public int weaponRange = 100;

    public float fireRate = 0.1f;
    private float nextFire = 0;
    private Ray ray;
    private RaycastHit hit;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;

    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                Debug.Log("Hit!");
                ShootableRobot health = hit.collider.GetComponent<ShootableRobot>();

                if (health != null)
                {
                    health.Damage(weaponDamage);
                }
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        Debug.Log("shot!");
        gunAudio.Play();
        yield return shotDuration;
    }
}