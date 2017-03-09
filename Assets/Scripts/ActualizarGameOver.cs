using UnityEngine;
using System.Collections;

public class ActualizarGameOver : MonoBehaviour {

	public TextMesh total;
	public TextMesh record;

	public Puntuacion puntuacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Método que se activa automaticamente al ser activado el GameObject que posea este script
	void OnEnable () {
		total.text = puntuacion.puntuacion.ToString();
		if (EstadoJuego.estadoJuego != null) {
			record.text = EstadoJuego.estadoJuego.PuntuacionMaxima.ToString ();
		}
	}
}
