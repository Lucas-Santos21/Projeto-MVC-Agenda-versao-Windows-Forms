using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_MVC_Agenda_WinForms
{
    class Contato
    {
        //Propriedades

        private string _email;
        private string _nome;
        private Data _dtNasc;
        private List<Telefone> _telefones = new List<Telefone>();

        //Construtores

        public Contato()
        {
            Email = "";
            Nome = "";
            DtNasc = new Data();
        }

        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
        }

        //Getters e Setters

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public Data DtNasc
        {
            get { return _dtNasc; }
            set { _dtNasc = value; }
        }

        public List<Telefone> Telefones
        {
            get { return _telefones; }
            set { _telefones = value; }
        }

        //Metodos publicos

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - DtNasc.Ano;

            if (hoje.Month < DtNasc.Mes || (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
            {

                idade--;

            }

            return idade;
        }

        public void adicionarTelefone(string valor, Telefone t)
        {
            string decide = valor.ToLower();

            if (Telefones.Count == 0)
            {

                t.Principal = true;

                Telefones.Add(t);

            }
            else
            {

                if (decide == "sim")
                {

                    Telefones[0].Principal = false;

                    t.Principal = true;
                    Telefones.Insert(0, t);

                }
                else if (decide == "nao")
                {

                    Telefones.Add(t);

                }
                else
                {

                    Console.WriteLine("Declare com 'sim' ou 'nao' se o telefone será cadastrado como principal");

                }

            }
        }

        public string getTelefonePrincipal()
        {
            string saida;

            if (Telefones.Count == 0)
            {

                saida = "Nenhum telefone foi cadastrado ainda!";


            }
            else
            {

                saida = $"Tipo do Telefone principal: {Telefones[0].Tipo}, Numero do telefone: {Telefones[0].Numero}, ";

            }

            return saida;

        }

        public override string ToString()
        {
            string saida = "";

            saida += $"Nome do contato: {Nome}, Email do contato: {Email}, Idade do Contato: {getIdade()} \n ";

            for (int i = 0; i < Telefones.Count; i++)
            {

                if (i == 0)
                {

                    saida += $"Tipo do telefone principal: {Telefones[i].Tipo}, numero do telefone principal: {Telefones[i].Numero} \n";

                }
                else
                {

                    saida += $"Tipo do telefone {i + 1}: {Telefones[i].Tipo}, numero do telefone: {Telefones[i].Numero} \n";

                }

            }

            return saida;

        }

        public override bool Equals(object obj)
        {

            if (obj == null || !(obj is Contato))
            {

                return false;

            }


            Contato outro = (Contato)obj;

            return Email == outro.Email;
        }

        public string TelefonesStr
        {
            get
            {
                return string.Join(", ", Telefones.Select(t => t.Numero));
            }
            set
            {
                Telefones = value
                    .Split(',')
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Select((t, i) => new Telefone("Celular", t.Trim(), i == 0))
                    .ToList();
            }
        }

    }
}
