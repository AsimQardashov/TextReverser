using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    internal class DataReader
    {
        public List<Data> GetData(string filePath)
        {
            var result = new List<Data>();

            if (File.Exists(filePath))
            {
                using StreamReader file = new StreamReader(filePath);

                while (file.ReadLine() is { } line)
                {
                    result.Add(new Data { Text = line });
                }

                file.Close();
            }

            return result;
        }
    }
}
