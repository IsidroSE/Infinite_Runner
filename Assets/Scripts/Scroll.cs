using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;
	public bool IniciarEnMovimiento = false;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		if (IniciarEnMovimiento) {
			PersonajeEmpiezaACorrer();
		}
	}

	void PersonajeEmpiezaACorrer() {
		enMovimiento = true;
		tiempoInicio = Time.time;
	}

	void PersonajeHaMuerto() {
		enMovimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enMovimiento) {
			GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
}
