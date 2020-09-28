using System;
using System.Collections.Generic;
using System.Text;

namespace Omt.Domain
{
    public class ApiResponse
    {
        /// <summary>
        /// Inicia a resposta sem sucesso
        /// </summary>
        public ApiResponse()
        {
            Sucess = false;
            Messages = new List<string>();
        }

        public bool Sucess { get; set; }
        public IList<string> Messages { get; set; }
        public object Content { get; set; }

        /// <summary>
        /// Cria a <see cref="ApiResponse"/> em Sucesso. O objeto de retorno é opcional.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public ApiResponse AddSuccess(object content = null)
        {
            Sucess = true;
            if (content != null)
                Content = content;

            return this;
        }

        /// <summary>
        /// Cria a <see cref="ApiResponse"/> em Falha. A mensagem é obrigatória.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public ApiResponse AddFailure(string message, object content = null)
        {
            Sucess = false;
            Messages.Add(message);
            if (content != null)
                Content = content;

            return this;
        }
    }
}
