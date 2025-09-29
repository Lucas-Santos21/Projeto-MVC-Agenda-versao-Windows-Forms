using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Agenda_WinForms
{
    class Telefone
    {
        //Propriedades

        private string _tipo;
        private string _numero;
        private bool _principal;

        //Construtores

        public Telefone()
        {
            Tipo = "";
            Numero = "";
            Principal = false;
        }

        public Telefone(string tipo, string numero, bool principal)
        {
            Tipo = tipo;
            Numero = numero;
            Principal = principal;
        }

        //Getters e Setters

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public bool Principal
        {
            get { return _principal; }
            set { _principal = value; }
        }

    }
}
