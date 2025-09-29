using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Agenda_WinForms
{
    class Data
    {
        //Propriedades

        private int _dia;
        private int _mes;
        private int _ano;

        //Construtor

        public Data()
        {
            Dia = 0;
            Mes = 0;
            Ano = 0;
        }

        //getters e Settes

        public int Dia
        {
            get { return _dia; }
            set { _dia = value; }
        }

        public int Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }

        //Metodos Publicos

        public void setData(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;

        }

        public override string ToString()
        {
            return $"{Dia}/{Mes}/{Ano}";
        }

    }
}
