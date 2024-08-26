using Dapper;
using ProjetoAula03.Entities;
using ProjetoAula03.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Repositories
{
    /// <summary>
    /// Classe de repositorio de dados para a entidade Funcionario
    /// </summary>
    public class FuncionarioRepository : IBaseRepository<Funcionario>
    {
        //atributo
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula03;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Funcionario obj)
        {
            var sql = @"
                    INSERT INTO FUNCIONARIO(ID, NOME, MATRICULA, CPF, DATAADMISSAO, EMPRESAID)
                    VALUES(@Id, @Nome, @Matricula, @Cpf, @DataAdmissao, @EmpresaId)
                ";
            Console.WriteLine(sql);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public void Update(Funcionario obj)
        {
            var sql = @"
                    UPDATE FUNCIONARIO SET
                        NOME = @Nome,
                        MATRICULA = @Matricula,
                        CPF = @Cpf,
                        DATAADMISSAO = @DataAdmissao,
                        EMPRESAID = @EmpresaId
                    WHERE
                        ID = @Id
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public void Delete(Funcionario obj)
        {
            var sql = @"
                    DELETE FROM FUNCIONARIO
                    WHERE ID = @Id
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public List<Funcionario> GetAll()
        {
            var sql = @"
                    SELECT * FROM FUNCIONARIO
                    ORDER BY
                        NOME ASC
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(sql).ToList();
            }
        }
    }
}