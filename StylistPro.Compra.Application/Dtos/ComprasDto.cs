using StylistPro.Compra.Domain.Interfaces.Dtos;
using FluentValidation;

namespace StylistPro.Compra.Application.Dtos
{
    public class ComprasDto : IComprasDto
    {
        public DateTime DataDaCompra { get; set; }
        public string Status { get; set; } = string.Empty;

        public void Validate()
        {
            var validateResult = new ComprasDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class ComprasDtoValidation : AbstractValidator<ComprasDto>
    {
        public ComprasDtoValidation()
        {
            RuleFor(x => x.DataDaCompra)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataDaCompra)} não pode ser vazio");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Status)} não pode ser vazio");
        }
    }
}
