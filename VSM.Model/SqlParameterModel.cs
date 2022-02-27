using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VSM.Model
{
    public class SqlParameterModel
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
        public SqlDbType Type { get; set; }
        public bool IsOutput { get; set; }
    }
}
