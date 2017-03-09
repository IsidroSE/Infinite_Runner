using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

	public int puntuacion = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeHaMuerto");
		ActualizarMarcador();
	}

	void PersonajeHaMuerto (Notification notificacion) {
		if (puntuacion > EstadoJuego.estadoJuego.PuntuacionMaxima) {
			EstadoJuego.estadoJuego.PuntuacionMaxima = puntuacion;
			EstadoJuego.estadoJuego.Guardar ();
		}
	}

	void IncrementarPuntos (Notification notificacion) {
		int puntosAIncrementar = (int)notificacion.data;
		puntuacion += puntosAIncrementar;
		//Debug.Log("Incrementaando"+puntosAIncrementar+" puntos. Total ganados: "+puntuacion);
		ActualizarMarcador();
	}

	void ActualizarMarcador () {
		marcador.text = puntuacion.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
