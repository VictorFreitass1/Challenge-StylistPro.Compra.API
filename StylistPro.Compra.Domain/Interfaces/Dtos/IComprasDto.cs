namespace StylistPro.Compra.Domain.Interfaces.Dtos
{
    public interface IComprasDto
    {
        public DateTime DataDaCompra { get; set; }
        public string Status { get; set; }
        void Validate();
    }
}
