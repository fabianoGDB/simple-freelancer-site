using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public FinishProjectCommand(int id, string creditCardNumber, string cvv, string epiresAt, string fullName)
        {
            Id = id;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            EpiresAt = epiresAt;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string EpiresAt { get; set; }
        public string FullName { get; set; }

    }
}
