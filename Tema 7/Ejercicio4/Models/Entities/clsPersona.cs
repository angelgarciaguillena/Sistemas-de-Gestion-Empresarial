namespace Ejercicio4.Models.Entities
{
    public class clsPersona
    {
        #region atributos privados
        private int _id;
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private int _edad;
        private clsDepartamento _dpto = new clsDepartamento(0, "");
        #endregion

        #region getters y setters
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        public clsDepartamento Departamento
        {
            get { return _dpto; }
            set { _dpto = value; }
        }
        #endregion

        #region constructores
        public clsPersona()
        {
        }

        public clsPersona(int id, string nombre, string apellidos, int edad, clsDepartamento departamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _edad = edad;
            _dpto = departamento;
        }
        #endregion
    }
}