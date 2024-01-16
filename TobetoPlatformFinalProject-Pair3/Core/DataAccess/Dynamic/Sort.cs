using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Dynamic
{
    public class Sort
    {
        public string Field { get; set; } // Sıralama işlemi için kullanılacak alanın adı.
                                          // Field özelliği, sıralama işlemi için kullanılacak alanın adını
                                          // (örneğin, bir veritabanı tablosundaki bir sütun adı) temsil eder.
        public string Dir { get; set; } // Sıralama türünü (artan, azalan) temsil eden bir özellik.

        public Sort()
        {
            Field = string.Empty;
            Dir = string.Empty;
        }

        public Sort(string field, string dir)
        {
            Field = field;
            Dir = dir;
        }
    }
}
