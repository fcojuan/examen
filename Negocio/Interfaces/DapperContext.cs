namespace Negocio.Interfaces
{
    public class DapperContext
    {
        public DapperContext(string value) => Value = value;
        public string Value { get; }
    }
}
