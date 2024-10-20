using UnityEngine;
public class CameraController : MonoBehaviour
{
	public float moveSpeed = 10f; // Velocidad de movimiento de la c�mara 
	public float lookSpeed = 100f; // Velocidad de rotaci�n de la c�mara 
	[SerializeField]
	GameObject player;

	private Camera Camera;


	private void Start()
	{
		Camera = GetComponent<Camera>();
	}
	void Update()
	{
		handleMove();
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Camera.main.transform.position = player.transform.position + new Vector3(0, 1.6f,
			0); // Posici�n relativa a la cabeza del jugador 
			Camera.main.transform.rotation = player.transform.rotation; // Orientaci�n igual al jugador
																		
		}

		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Camera.main.transform.position = player.transform.position + new Vector3(0, 2, -5);
			// Posici�n detr�s del jugador 
			Camera.main.transform.LookAt(player.transform); // C�mara mirando hacia el jugador
        }

		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Camera.main.transform.position = player.transform.position + new Vector3(0, 10,
			0); // Posici�n sobre el jugador 
			Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0); // Rotaci�n para mirar hacia abajo
        }



	}


	public void handleMove()
	{
		// Movimiento con teclas WASD 
		float moveHorizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A, D) 
		float moveVertical = Input.GetAxis("Vertical"); // Movimiento hacia adelante y atr�s(W, S)

		// Aplicar el movimiento 
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
		// Rotaci�n con el mouse 
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
		// Aplicar la rotaci�n horizontal 
		transform.Rotate(Vector3.up * mouseX);
		// Aplicar la rotaci�n vertical (eje Y invertido para una mejor sensaci�n) 
		transform.Rotate(Vector3.left * mouseY);

	}



}

