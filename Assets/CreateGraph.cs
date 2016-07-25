using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateGraph : MonoBehaviour {

	public InputField input;
	public Button boton;
	string textoInput;
	float camHeight;
	float camWidth;
	Rect rec;
	public createArk ca;

	GameObject seleccion1;
	GameObject seleccion2;

	void Awake()
	{
		seleccion1 = null;
		seleccion2 = null;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		verificacionSeleccion ();
	}

	public void enterNodes()
	{
		textoInput = input.GetComponent<InputField> ().text;

		int cantidad = int.Parse (textoInput);

		createNodes (cantidad);

		input.GetComponent<InputField> ().text = "";

		changeState (input.gameObject);

		changeState (boton.gameObject);

	}

	void createNodes(int cantidad)
	{
		//getCamHeighWidth ();
		//Debug.Log ("numero de vertices: " + cantidad); Checked

		for (int i = 0; i < cantidad; i++)
		{
//			float randomX = Random.Range (0, camWidth);
//			float randomY = Random.Range (0, camHeight);

			GameObject nuevo = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			Vector3 temp = new Vector3 (Random.Range(-10.0f,10.0f), Random.Range(-4.2f,6.10f), 0 );
			nuevo.transform.position = temp;
			nuevo.GetComponent<MeshRenderer> ().material.color = Color.red;
			nuevo.tag = "nodo";
		}
	}

	void getCamHeighWidth()
	{
//		Camera cam = Camera.main;
//
//		rec = cam.pixelRect;
//
//		camHeight = cam.pixelHeight;
//		camWidth  =cam.pixelWidth;

	

		//Debug.Log ("numero de  pixels height : " + camHeight); Checked
		//Debug.Log ("numero de pixel width : " + camWidth);  Checked
	}

	void changeState(GameObject go)
	{
		if (go.activeSelf == true) {
			go.SetActive (false);
		} else {
			go.SetActive (true);
		}
	}

	void verificacionSeleccion()
	{
		GameObject go = devolverGO ();

		if (go == null) {

		} else {
			
			if (go.tag == "nodo") {
				
					if (seleccion1 != null) {
					seleccion2 = go;
						CreateArc ();


				} else if (seleccion1 == null && seleccion2 == null) {
				
					seleccion1 = go;
					cambiarColorActive (seleccion1.GetComponent<MeshRenderer> ());
				}
			}
		}
	}



	void CreateArc()
	{
		if (seleccion1 == seleccion2) {
			cambiarColorDisActive (seleccion1.GetComponent<MeshRenderer> ());
			seleccion1 = null;
			seleccion2 = null;

		} else {
			cambiarColorActive (seleccion2.GetComponent<MeshRenderer> ());
			crearArco( seleccion1 ,  seleccion2);
		}
	}

	void crearArco(GameObject go1, GameObject go2)
	{
		createArk ca =	new createArk (go1, go2, this);

	}

	GameObject devolverGO()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Debug.Log (ray);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "nodo") {
					return hit.collider.gameObject;

				} else {
					return null;
				}
			}
		} else {
			return null;
		}
		return null;
	}

	void cambiarColorActive(MeshRenderer mr)
	{
		mr.material.color = Color.green;
	}
	void cambiarColorDisActive(MeshRenderer mr)
	{
		mr.material.color = Color.red;
	}

}
