using Domain.Entities;

namespace UI.Models
{
    /// <summary>
    /// Modelo de la capa UI que representa una persona con color asignado
    /// </summary>
    public class PersonaConColor
    {
        /// <summary>
        /// Persona elegida
        /// </summary>
        private Persona _persona;

        /// <summary>
        /// Lista de departamentos disponibles para seleccionar
        /// </summary>
        private List<Departamento> _departamentos;

        /// <summary>
        /// Color asignado según el departamento de la persona
        /// </summary>
        private string _colorDepartamento;

        /// <summary>
        /// Get de la persona del modelo PersonaConColor
        /// </summary>
        public Persona Persona
        {
            get { return _persona; }
        }

        /// <summary>
        /// Get de la lista de departamentos del modelo PersonaConColor
        /// </summary>
        public List<Departamento> Departamentos
        {
            get { return _departamentos; }
        }

        /// <summary>
        /// Get del color asignado al departamento del modelo PersonaConColor
        /// </summary>
        public String ColorDepartamento
        {
            get { return _colorDepartamento; }
        }

        /// <summary>
        /// Constructor que inicializa la persona con sus departamentos y su color
        /// </summary>
        /// <param name="persona">Persona a mostrar</param>
        /// <param name="departamentos">Lista de departamentos disponibles</param>
        /// <param name="colorDepartamento">Color asignado según el departamento</param>
        public PersonaConColor(Persona persona, List<Departamento> departamentos, string colorDepartamento)
        {
            _persona = persona;
            _departamentos = departamentos;
            _colorDepartamento = colorDepartamento;
        }
    }
}