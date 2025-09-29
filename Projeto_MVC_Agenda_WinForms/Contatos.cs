using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Agenda_WinForms
{
    class Contatos
    {
        //Propriedades

        private List<Contato> _agenda;

        //Construtor

        public Contatos()
        {

            _agenda = new List<Contato>();

        }

        //Getters e Setters

        public List<Contato> Agenda
        {
            get { return _agenda; }
        }

        //Metodos publicos

        public bool adicionar(Contato c)
        {
            bool adicionado = false;

            if (_agenda.Contains(c))
            {

                Console.WriteLine("Este contato já existe!");

            }
            else
            {
                _agenda.Add(c);
                adicionado = true;
            }

            return adicionado;

        }

        public Contato pesquisar(Contato c)
        {
            Contato saida = null;

            saida = _agenda.Find(cont => cont.Equals(c));

            return saida;
        }

        public bool alterar(Contato c)
        {
            bool saida = false;

            if (_agenda.Contains(c))
            {

                _agenda[_agenda.IndexOf(_agenda.Find(cont => cont.Equals(c)))] = c;
                saida = true;

            }
            else
            {

                Console.WriteLine("Contato não encontrado");

            }

            return saida;

        }

        public bool remover(Contato c)
        {
            bool removido = false;

            if (_agenda.Contains(c))
            {

                _agenda.Remove(c);
                removido = true;

            }

            return removido;
        }

    }
}
