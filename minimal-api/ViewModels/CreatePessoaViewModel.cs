using Flunt.Notifications;
using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace minimal_api.ViewModels
{
    public class CreatePessoaViewModel : Notifiable<Notification>
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public bool Ativo { get; set; }

        public pessoa MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Informe o Nome da pessoa")
                .IsNotNull(Profissao, "Informe a profissão")
                .IsGreaterThan(Nome, 5, "O Nome deve conter mais de 5 caracteres"));

            return new pessoa(Guid.NewGuid(), Nome, Profissao, Ativo);
        }
    }
}
