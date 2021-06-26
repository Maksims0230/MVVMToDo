using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;

namespace ToDo_WPF.Statics
{
    /// <summary>
    ///     FireBase данные
    /// </summary>
    public static class FireBaseInfo
    {
        /// <summary>
        ///     Данные для аутентификации
        /// </summary>
        public static class AuthReg
        {
            /// <summary>
            ///     (Web) Api ключ Fire Base
            /// </summary>
            public static string ApiKey { get; } = "AIzaSyCwr9cdftW-rGOVbkV91Ln-A279Wtuk7SI";

            /// <summary>
            ///     Домен FireBase AuthReg
            /// </summary>
            public static string Domain { get; } = "todolist-a5e59.firebaseapp.com";

            /// <summary>
            ///     Провайдер для FireBase AuthReg
            /// </summary>
            public static FirebaseAuthProvider Provider { get; } = new(new FirebaseConfig(ApiKey));
        }

        /// <summary>
        ///     Данные для управления базой данных
        /// </summary>
        public static class Data
        {
            /// <summary>
            ///     Секретный ключ для FireBase Database
            /// </summary>
            public static string SecretKey { get; } = "DyJJ3vBf5iwiEOkZ8tCoCqw582dukJbbXc8dAywT";

            /// <summary>
            ///     Ссылка до FireBase Database
            /// </summary>
            public static string Url { get; } = "https://todolist-a5e59-default-rtdb.firebaseio.com/";

            /// <summary>
            ///     Клиент для FirBase Database
            /// </summary>
            public static FirebaseClient Client { get; } = new(
                Url,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(SecretKey)
                });
        }
    }
}