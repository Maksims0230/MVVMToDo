using System.Linq;
using System.Threading.Tasks;
using static ToDo_WPF.Statics.FireBaseInfo.AuthReg;

namespace ToDo_WPF.Models
{
    public class FireBaseModel
    {
        /// <summary>
        ///     Метод регистрации в FireBase
        /// </summary>
        public static async void FbRegister(string email, string password)
        {
            var auth = await Provider.CreateUserWithEmailAndPasswordAsync(email, password,
                email.Split(new[] {'@'}).First(), true);
        }

        /// <summary>
        ///     Метод аутентификации в FireBase
        /// </summary>
        public static async Task<bool> FbAuth(string email, string password)
        {
            var auth = await Provider.SignInWithEmailAndPasswordAsync(email, password);
            return auth != null;
        }
    }
}