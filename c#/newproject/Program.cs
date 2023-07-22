using MySql.Data.MySqlClient.Net Core Class Library;
MySqlConnection connection = new MySqlConnection
{
ConnectionString = @"server=localhost;user
id=root;password=vuong123;port=3306;database=employees;"

};
connection.Open();
