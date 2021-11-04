using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    class BoBeneficiario
    {

        /// <summary>
        /// Inclui um novo Beneficiario !Incompleto
        /// </summary>
        /// <param name="Beneficiario">Objeto de Beneficiario</param>

        public void Salvar(List<DML.Beneficiario> beneficiarios, long idCliente)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            List<DML.Beneficiario> benPersistidos = ben.Listar(idCliente);            

            for (int i = 0; i < beneficiarios.Count; i++)
            {
                if (true)
                    ben.Alterar(beneficiarios[i]);
            }
        }
        /// <summary>
        /// Inclui um novo Beneficiario
        /// </summary>
        /// <param name="Beneficiario">Objeto de Beneficiario</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um Beneficiario
        /// </summary>
        /// <param name="Beneficiario">Objeto de Beneficiario</param>
        public void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            ben.Alterar(beneficiario);            
        }

        /// <summary>
        /// Consulta o Beneficiario pelo id
        /// </summary>
        /// <param name="id">id do Beneficiario</param>
        /// <returns></returns>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Consultar(id);
        }

        /// <summary>
        /// Excluir o Beneficiario pelo id
        /// </summary>
        /// <param name="id">id do Beneficiario</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            ben.Excluir(id);
        }

        /// <summary>
        /// Lista os Beneficiarios
        /// </summary>
        public List<DML.Beneficiario> Listar(long idCliente)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Listar(idCliente);
        }

        /// <summary>
        /// Lista os Beneficiarios
        /// </summary>
        public List<DML.Beneficiario> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF, long idCliente)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.VerificarExistencia(CPF, idCliente);
        }

        /// <summary>
        /// Verifica se cpf é valido
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool CPFValido(string CPF)
        {
            CPF = CPF.Trim().Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            int[] somar = new int[2] { 0, 0 };
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string digito;
            for (int i = 0; i < 10; i++)
            {
                if (i < 9) somar[0] += int.Parse(CPF[i].ToString()) * multiplicador1[i];
                somar[1] += int.Parse(CPF[i].ToString()) * multiplicador2[i];
            }
            digito = ((somar[0] % 11) < 2 ? 0 : 11 - somar[0] % 11).ToString();
            digito += ((somar[1] % 11) < 2 ? 0 : 11 - somar[1] % 11).ToString();
            return CPF.EndsWith(digito);
        }
    }
}
