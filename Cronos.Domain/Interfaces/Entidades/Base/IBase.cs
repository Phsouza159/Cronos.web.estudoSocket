using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cronos.Domain.Interfaces.Entidades.Base
{
    public interface IBase<tEnity> : INotifiable where tEnity : class
    {
        [Key]
        int Id { get; set; }
        bool Situacao { get; set; }
        DateTime DataInclusao { get; set; }

        /// <summary>
        /// Valida o objeto e rotorna o mesmo
        /// </summary>
        /// <returns></returns>
        tEnity Valid();
    }
}
