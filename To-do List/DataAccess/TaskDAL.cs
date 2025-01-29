using Microsoft.Data.SqlClient;
using To_do_List.DTOs.Task;

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

        public List<ShowTaskDTO> GetTasks(string email)
        {
            string command = @"
            SELECT
	            cd_tarefa,
	            nm_titulo_tarefa,
	            ds_tarefa,
	            dt_vencimento_tarefa,
	            ic_concluido_tarefa
            FROM tarefa
            WHERE nm_email_usuario = @Email";

            List<SqlParameter> parameters = new List<SqlParameter>
            { 
                new SqlParameter("Email", email)
            };

            List<ShowTaskDTO> tasks = new List<ShowTaskDTO>();

            using (SqlDataReader reader = _database.ExecuteQuery(command, parameters))
            {
                while (reader.Read())
                {
                    ShowTaskDTO task = new ShowTaskDTO
                    {
                         Id = reader.GetInt32(0),
                         Title = reader.GetString(1),
                         Description = reader.GetString(2),
                         DueDate = reader.IsDBNull(3) ? "" : reader.GetDateTime(3).ToString("dd/MM/yyyy"),
                         IsCompleted = reader.GetBoolean(4)
                    };

                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public void CompleteTask(int taskId)
        {
            string command = @"
            UPDATE tarefa
            SET ic_concluido_tarefa = 1
            WHERE cd_tarefa = @IdTask";

            List<SqlParameter> parameters = new List<SqlParameter>
            { 
                new SqlParameter("IdTask", taskId)
            };

            _database.ExecuteCommand(command, parameters);
        }

        public bool CheckTaskExistence(int taskId, string email)
        {
            string command = @"
            SELECT 1 FROM tarefa
            WHERE 
                cd_tarefa = @IdTask AND
                nm_email_usuario = @Email
            ";

            List<SqlParameter> parameters = new List<SqlParameter>
            { 
                new SqlParameter("IdTask", taskId),
                new SqlParameter("Email", email)
            };

            bool doesTaskExist = false;

            using (SqlDataReader reader = _database.ExecuteQuery(command, parameters))
            {
                if (reader.Read())
                {
                    doesTaskExist = reader.GetInt32(0) == 1 ? true : false;
                }
            }

            return doesTaskExist;
        }
    }
}
