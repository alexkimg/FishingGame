using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BobberSpawner : MonoBehaviour
{
    [SerializeField] LayerMask waterLayers;
    private Vector3 mousePosition;

    private Bobber bobberIndicator;
    public bool lineIsCast = false;

    private bool spawnerIsActive = false;


    [SerializeField] HUDmanager hudManager;

    [SerializeField] Bobber bobber;
    private void Awake()
    {
        // Intial setup
        spawnerIsActive = false;
    }

    private void Update()
    {
        if (lineIsCast == false && spawnerIsActive == false && Input.GetMouseButtonUp(0))
        {
                
            StartCastingLine(bobber);
        
        }

        if (spawnerIsActive == true)
        {
            bobberIndicator.transform.position = GetMousePosition();

            if (Input.GetMouseButton(0))
            {
                bobber.ActivateBobber();
                bobberIndicator = null;
                lineIsCast = true;
                spawnerIsActive =false;
            }
            else if (Input.GetMouseButton(1)) 
            {
                Destroy(bobberIndicator.gameObject);
                spawnerIsActive=false;
            }
        }
       
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 500f, waterLayers))
        {

            Debug.DrawLine(Camera.main.transform.position, hit.point,
                Color.red);
                      
        }
        return hit.point;
    }
    private void StartCastingLine(Bobber newBobber)
    {
      
            bobberIndicator = Instantiate(newBobber, mousePosition, Quaternion.identity);
            bobber.isDetectable = false;
            spawnerIsActive = true;
            hudManager.status = "Casting Line!";
            hudManager.UpdateStatus();

    }
}
