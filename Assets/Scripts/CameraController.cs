using UnityEngine;
public class CameraController : MonoBehaviour
{
	public float moveSpeed = 10f; // Velocidad de movimiento de la cámara 
	public float lookSpeed = 100f; // Velocidad de rotación de la cámara 
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
			0); // Posición relativa a la cabeza del jugador 
			Camera.main.transform.rotation = player.transform.rotation; // Orientación igual al jugador
																		
		}

		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Camera.main.transform.position = player.transform.position + new Vector3(0, 2, -5);
			// Posición detrás del jugador 
			Camera.main.transform.LookAt(player.transform); // Cámara mirando hacia el jugador
        }

		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Camera.main.transform.position = player.transform.position + new Vector3(0, 10,
			0); // Posición sobre el jugador 
			Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0); // Rotación para mirar hacia abajo
        }



	}


	public void handleMove()
	{
		// Movimiento con teclas WASD 
		float moveHorizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (A, D) 
		float moveVertical = Input.GetAxis("Vertical"); // Movimiento hacia adelante y atrás(W, S)

		// Aplicar el movimiento 
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
		// Rotación con el mouse 
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
		// Aplicar la rotación horizontal 
		transform.Rotate(Vector3.up * mouseX);
		// Aplicar la rotación vertical (eje Y invertido para una mejor sensación) 
		transform.Rotate(Vector3.left * mouseY);

	}



}

