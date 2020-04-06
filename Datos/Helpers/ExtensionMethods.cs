using System.Collections.Generic;
using System.Linq;
using Datos.Models;

namespace Datos.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<LoginModel> WithoutPasswords(this IEnumerable<LoginModel> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static LoginModel WithoutPassword(this LoginModel user) {
            user.Password = null;
            return user;
        }
    }
}