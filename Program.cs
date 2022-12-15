using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

string connectionLine = @"DESKTOP-IPH870M\User;Database=Department;Trusted_Connection=True";

//List<Size> GetAllEmployees()
//{
//    List<Size> employeeList = new List<Size>();
//    using (SqlConnection connection = new SqlConnection(connectionLine))
//    {
//        connection.Open();
//        string query = $"Select * from Employee";
//        SqlCommand command = new(query, connection);
//        SqlDataReader reader = command.ExecuteReader();

//        if (reader.HasRows)
//        {

//            while (reader.Read())
//            {
//                Size size = new()
//                {
//                    Id = (int)reader["Id"],
//                    Name = (string)reader["Name"],
//                    Surname = (string)reader["Surname"],
//                    Salary = (int)reader["Salary"]

//                };
//                employeeList.Add(size);
//            }
//        }

//    }

//    return employeeList;
//}






try
{
    foreach (var item in GetEmployeeByIdBy(id))
    {
        Console.WriteLine(item.SizeValue);
    }
}
catch (NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

IEnumerable<object> GetEmployeeByIdBy(int id)
{
    throw new NotImplementedException();
}

int id = 2;
List<int> GetEmployeeById(int id)
{
    List<int> ChooseList = new List<int>();
    using (SqlConnection connection = new SqlConnection(connectionLine))
    {
        connection.Open();
        string querycode = $"SELECT * FROM Sizes WHERE Size LIKE '%' + @id + '%'";
        SqlCommand command = new(querycode, connection);
        SqlDataReader reader=command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                int size = new()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Salary = (int)reader["Salary"]
                };
                ChooseList.Add(size);
            }
        }
        else
        {
            throw new NotFoundException("data not found");
        }
    }

    return ChooseList;
}
    

