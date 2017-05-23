using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWClient
{
    public class StepInfo
    {
        private string nameVal;

        public string Name
        {
            get { return nameVal; }
            set { nameVal = value; }
        }

      

        private string jsonVal;

        public string Json
        {
            get { return jsonVal; }
            set { jsonVal = value; }
        }
        public override string ToString()
        {
            return Name;
        }

        public StepInfo(string name, string json)
        {
            this.nameVal = name;

            this.Json = json;
        }

        /// <summary>  
        /// 构造一个用户信息数组【绑定到listbox的数据源】  
        /// </summary>  
        public static StepInfo[] Steps =  
            {   
            };
    }
}