using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public static class UniqueId
    {
        private const int minId = 10000;
        private const int maxId = 99999;

        private static int numberId = minId;

        public static int GenerateId()
        {

            numberId++;
            return numberId;
        }
    }
}
