using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using To_do_List.DataAccess;
using To_do_List.DTOs.User;
using To_do_List.Models;

namespace To_do_List.Services
{
    public class UserService
    {
        public readonly UserDAL _userDAL;

        public UserService(UserDAL userDAL)
        {
            _userDAL = userDAL;
        }
    }
}
