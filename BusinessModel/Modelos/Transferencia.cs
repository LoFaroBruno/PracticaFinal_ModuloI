using System;

namespace BusinessModel.Modelos
{
    public class Transferencia
    {
        public string Nombre;
        public float Monto;
        public DateTime HoraFecha;
        public bool Inmediata;
        public string CBUOrigen;
        public string CBUDestino;
        public string CodigoActividadAFIP;
        public string ClaveTributaria;
    }
}