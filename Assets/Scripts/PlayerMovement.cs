using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public static PlayerMovement Instance;
    private Vector3 prevmousePos;
    private Vector3 currentmousePos;
    private Vector3 deltamousePos;
    public float movementSpeed;
    public float smoothTime;
    public GameObject centerObj;
    public GameObject backSphere;

    public float xMinLimit;
    public float xMaxLimit;
    private Vector3 target;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (GameManager.Instance.gameStatus == Enums.GameStatus.ready || GameManager.Instance.gameStatus == Enums.GameStatus.gameEnd)
        {
           RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                float slopeAngle = Vector3.Angle(hit.normal, Vector3.up); // yamaç açýsýný hesaplayýn
                if (slopeAngle > 0 && slopeAngle <= 45f) // nesneyi sadece belirli bir eðim açýsýnýn altýnda hareket ettirin
                {
                    Vector3 slopeDirection = Vector3.Cross(Vector3.up, hit.normal); // yamaç yönünü hesaplayýn
                    float slopeSpeedModifier = Mathf.Cos(slopeAngle * Mathf.Deg2Rad); // eðim açýsýna baðlý hýz ayarý hesaplayýn
                    transform.Translate(slopeDirection * movementSpeed * slopeSpeedModifier * Time.deltaTime); // nesneyi yamaç eðimine göre hareket ettirin
                }
                else
                {
                   
                }
                Debug.Log("girdi raycast");
            }
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
            if (Input.GetMouseButtonDown(0))
            {
                currentmousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                prevmousePos = currentmousePos;
                currentmousePos = Input.mousePosition;
                deltamousePos = currentmousePos - prevmousePos;
                target = new Vector3(deltamousePos.x, 0);
                transform.position = Vector3.SmoothDamp(transform.position, transform.position + target / 2, ref velocity, smoothTime);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMinLimit, xMaxLimit), transform.position.y, transform.position.z);

            }
            if (Input.GetMouseButtonUp(0))
            {
                transform.position = Vector3.SmoothDamp(transform.position, transform.position, ref velocity, 0);
            }
        }
        else if (GameManager.Instance.gameStatus == Enums.GameStatus.gameEnd)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
      
    }

    public void CharacterMoveSpeed(float speed)
    {
        movementSpeed = speed;
    }
}

