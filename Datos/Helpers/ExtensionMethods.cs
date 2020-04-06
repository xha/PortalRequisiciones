using System.Collections.Generic;
using System.Linq;
using Datos.Models;

namespace Datos.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<USUARIO_COMP> WithoutPasswords(this IEnumerable<USUARIO_COMP> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static USUARIO_COMP WithoutPassword(this USUARIO_COMP user) {
            user.USU_PASSWORD = null;
            return user;
        }
    }
}