import mysql from 'mysql';

const connection = mysql.createConnection({
  host: 'mandatory1-myqsql-server.mysql.database.azure.com',
  user: 'nicolaj@mandatory1-myqsql-server',
  password: 'nicolajkea',
  database: 'classicmodels',
  port: 3306
});

connection.connect((err: mysql.MysqlError) => {
  if (err) {
    console.error('error connecting: ' + err.stack);
    return;
  }
  console.log('connected as id ' + connection.threadId);

  connection.query('SHOW TABLES;', (error: mysql.MysqlError, results: any) => {
    if (error) {
      console.error('Error querying database: ' + error.stack);
      return;
    }

    console.log('Tables:', results);
  });

  // Delete the employee with employeeNumber 1002

  const query = `SELECT * FROM employees`;
  connection.query(query, (error, results) => {
    if (error) {
      return;
    }
  
    console.log(results);
  });

  // Don't work due to dependencies

  // const values = [1002];
  // const deletequery = `DELETE FROM employees WHERE employeeNumber = ${values[0]}`;
  // connection.query(deletequery, values, (error, results: any) => {
  //   if (error) {
  //     console.error('Error deleting row: ' + error.stack);
  //     return;
  //   }

  //   console.log('Deleted ' + results.affectedRows + ' row(s) from employees');
  // });


});
