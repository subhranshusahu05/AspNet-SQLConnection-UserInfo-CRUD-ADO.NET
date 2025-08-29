
# 📖 ASP.NET WebForms + SQL Server CRUD (Without Stored Procedures)
## 1️⃣ Project Setup
* Created an **ASP.NET WebForms Application** in Visual Studio.
* Default page: `WebForm1.aspx`.
---
## 2️⃣ Database Setup
* Created a new database in SQL Server:
  ```sql
  CREATE DATABASE userinfoDB;
  ```
* Created a table:
  ```sql
  CREATE TABLE userinfo (
      roll INT PRIMARY KEY,
      name NVARCHAR(50),
      class NVARCHAR(50),
      addres NVARCHAR(200)
  );
```
---
## 3️⃣ Connection String
* Added to **Web.config**:

  ```xml
  <connectionStrings>
    <add name="userinfoConnectionString"
         connectionString="Data Source=YOUR_SERVER;Initial Catalog=userinfoDB;Integrated Security=True"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  ```

---

## 4️⃣ Form Design

* On `WebForm1.aspx`, added:

  * **TextBox1** → Roll
  * **TextBox2** → Name
  * **TextBox3** → Class
  * **TextBox4** → Address
  * **Buttons** → Insert, Update, Delete.

---

## 5️⃣ Insert Operation

* Code inside **Insert button click**:

  ```csharp
  SqlCommand cmd = new SqlCommand(
      "INSERT INTO userinfo (roll,name,class,addres) VALUES (@roll,@name,@class,@addres)", con);

  cmd.Parameters.AddWithValue("@roll", TextBox1.Text);
  cmd.Parameters.AddWithValue("@name", TextBox2.Text);
  cmd.Parameters.AddWithValue("@class", TextBox3.Text);
  cmd.Parameters.AddWithValue("@addres", TextBox4.Text);

  cmd.ExecuteNonQuery();  // Inserts record
  ```

---

## 6️⃣ Update Operation

* Code inside **Update button click**:

  ```csharp
  SqlCommand cmd = new SqlCommand(
      "UPDATE userinfo SET name=@name, class=@class, addres=@addres WHERE roll=@roll", con);

  cmd.Parameters.AddWithValue("@roll", TextBox1.Text);
  cmd.Parameters.AddWithValue("@name", TextBox2.Text);
  cmd.Parameters.AddWithValue("@class", TextBox3.Text);
  cmd.Parameters.AddWithValue("@addres", TextBox4.Text);

  cmd.ExecuteNonQuery();  // Updates record
  ```

---

## 7️⃣ Delete Operation

* Code inside **Delete button click**:

  ```csharp
  SqlCommand cmd = new SqlCommand(
      "DELETE FROM userinfo WHERE roll=@roll", con);

  cmd.Parameters.AddWithValue("@roll", TextBox1.Text);

  cmd.ExecuteNonQuery();  // Deletes record
  ```

---

## 9️⃣ Key Learnings

* **ExecuteNonQuery()** → Insert, Update, Delete (no data returned).
* **ExecuteReader()** → Read data (SELECT).
* **ExecuteScalar()** → Get a single value (like COUNT).
* Always close the connection: `con.Close();`.
* SQL Parameters (`@roll`, `@name`) must match exactly with the query.
1.INSERT
  <img width="1914" height="1034" alt="1Insert" src="https://github.com/user-attachments/assets/cc554b23-d984-4a28-be4b-e27ff8d6ad51" />
2.UPDATE
  <img width="1920" height="1018" alt="1Update" src="https://github.com/user-attachments/assets/4ca89dfe-283d-4121-b5d9-545a32225c37" />
3.DELETE
  <img width="1920" height="1010" alt="3Delete" src="https://github.com/user-attachments/assets/08fb3a59-51aa-44ad-8128-8102dc159b78" />
  
  

