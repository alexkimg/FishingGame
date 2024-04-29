using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(Collider))]
public class Fish : MonoBehaviour
{
    [SerializeField] FishPath path;
    [SerializeField] float speed = 3f;
    float range = 2f;
    private float rotationSpeed = 0.5f;

    //bobber bookkeping
    [SerializeField] Collider[] colliders;
    [SerializeField] Bobber bobber;
    [SerializeField] Bobber b;
    [SerializeField] Bobber targetBobber;
    [SerializeField] LayerMask bobberLayer;

    public bool isNibbling = false;
    public bool isHooked = false;
    public bool isReelable = false;
    
    private int currentTargetWaypoint = 0;

    private float randomDelayMin = 1f;
    private float randomDelayMax = 3f;

    public ItemDataSO itemData;
    private Collider myCollider;

    [SerializeField] EventManagerSO eventManager;

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
        myCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;
        if (inventory && isReelable)
        {
            inventory.InventorySystem.AddToInventory(itemData, 1);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        isNibbling = false;
        isHooked = false;
        isReelable = false;
    }

    private void OnEnable()
    {
        eventManager.OnFishBiting += HookFish;
    }
    private void OnDisable()
    {
        eventManager.OnFishBiting -= HookFish;
    }


    private void Update()
    {


        if (!isNibbling && !isHooked)
        {
            ScanForBobber();

            if (targetBobber != null)
            {
                if (targetBobber.isDetectable == true)
                {

                        transform.LookAt(targetBobber.transform.position);
                        transform.position = Vector3.MoveTowards(
                          transform.position,
                          targetBobber.transform.position,
                          (speed + 1f) * Time.deltaTime);

                        if (Vector3.Distance(transform.position, targetBobber.transform.position) <= 1f)
                        {
                            isNibbling = true;
                            targetBobber.isDetectable = false;
                            StartCoroutine(FishNibbling());


                        }





                    
                }
            }



            transform.LookAt(path.GetWaypoint(currentTargetWaypoint));

            transform.position = Vector3.MoveTowards(
                    transform.position,
                    path.GetWaypoint(currentTargetWaypoint).position,
                    speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, path.GetWaypoint(currentTargetWaypoint).position) < 0.1f)
            {
                currentTargetWaypoint = Random.Range(0, path.GetNumberOfWaypoints());
            }
        }




        else if (isNibbling)
        {
            bobber = FindObjectOfType<Bobber>();
            bobber.isDetectable = false;
            transform.position = Vector3.MoveTowards(
              transform.position,
              targetBobber.transform.position,
              speed * Time.deltaTime);
            transform.Rotate(0f, 45f * rotationSpeed * Time.deltaTime, 0f, Space.Self);




        }

        else if (isHooked && isReelable)
        {
            targetBobber.ReelIn();

            transform.position = Vector3.MoveTowards(
                        transform.position,
                        targetBobber.transform.position,
                        targetBobber.reelingSpeed * Time.deltaTime);
            
            
        }
    }

    private void ScanForBobber()
    {
        colliders = Physics.OverlapSphere(transform.position, range, bobberLayer);

        foreach (Collider collider in colliders)
        {
            targetBobber = collider.GetComponent<Bobber>();
        }
    }

    IEnumerator FishNibbling()
    {
        eventManager.FishNibbling();
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));
        eventManager.FishBiting();
        StopCoroutine(FishNibbling());
        
    }

    public void HookFish()
    {
        if (isNibbling == true)
        {
            Debug.Log($"Fish is hooked!");
            isNibbling = false;
            isHooked = true;
            //transform.position = Vector3.MoveTowards(
            //            transform.position,
            //            bobber.transform.position,
            //            bobber.reelingSpeed * Time.deltaTime);

        }
    }
}
