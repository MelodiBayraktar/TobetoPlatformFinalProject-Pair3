using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Dynamic;

namespace Core.DataAccess.Dynamic
{
    public class Filter
    {
        public string Field { get; set; } //filtreleme işleminde kullanılacak alanın adını temsil eder. Örneğin, bir veritabanı tablosundaki bir sütun adı.
        public string? Value { get; set; } //filtreleme işleminde kullanılacak değeri temsil eder. 
        public string Operator { get; set; } //filtreleme işleminde kullanılacak operatörü temsil eder. Operatör, bir karşılaştırma operatörü olabilir (örneğin, "eşittir", "büyüktür", "küçüktür") veya bir metin operatörü olabilir (örneğin, "içerir", "başlar", "biter").
        public string? Logic { get; set; } // birden çok filtreleme kriterini birleştiren mantıksal operatörü temsil eder. Örneğin, "ve" veya "veya"

        public IEnumerable<Filter>? Filters { get; set; } //birden çok alt filtreyi temsil eden bir koleksiyonu ifade eder. Bu, birden çok filtreleme kriterini bir araya getirerek karmaşık filtreleme mantıkları oluşturmanıza olanak tanır.

        public Filter()
        {
            Field = string.Empty;
            Operator = string.Empty;
        }

        public Filter(string field, string @operator)
        {
            Field = field;
            Operator = @operator;
        }
    }
}

//Filter filter = new Filter
//{
//    Field = "ProductName",
//    Operator = "contains",
//    Value = "Phone",
//    Logic = "and",
//    Filters = new List<Filter>
//    {
//        new Filter("Price", "greaterThan")
//        {
//            Value = "500"
//        },
//        new Filter("Stock", "lessThan")
//        {
//            Value = "10"
//        }
//    }
//};
