using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cronos.Domain.Servico
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">Entidade de tratamento do servico</typeparam>
    public class ServicoBase<TEntity> : Notifiable , INotifiable
        where TEntity : class
    {

        protected Expression<Func<TEntity, object>>[] includeProperties { get; set; }

        protected void Includes(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            this.includeProperties = includeProperties;
        }


    }
}
