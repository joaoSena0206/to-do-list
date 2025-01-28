using Microsoft.Data.SqlClient;
using To_do_List.Models;

namespace To_do_List.DataAccess
{
    public class TaskDAL
    {
        private readonly Database _database;

        public TaskDAL(Database database)
        {
            _database = database;
        }

        public void AddTask(Models.Task task)
        {
            string command = @"
            INSERT INTO tarefa (
	            nm_email_usuario, 
	            nm_titulo_tarefa,
	            ds_tarefa,
                dt_vencimento_tarefa,
	            ic_concluido_tarefa)
            VALUES (
	            @Email,
	            @Titulo,
	            @Descricao,
	            @Vencimento,
	            @FoiConcluido)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("Email", task.User.Email),
                new SqlParameter("Titulo", task.Title),
                new SqlParameter("Descricao", task.Description),
                new SqlParameter("Vencimento", task.DueDate ?? (object)DBNull.Value),
                new SqlParameter("FoiConcluido", task.IsCompleted)
            };

            _database.ExecuteCommand(command, parameters);
        }
    }
}
