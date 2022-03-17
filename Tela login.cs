Form1.cs

public Form1()
    {
      InitializeComponent();
    }
    private void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            string strcon = "server = 127.0.0.1; user id = root; database =
bdlogin";
              MySqlConnection cn = new MySqlConnection(strcon);
              cn.Open();
              MySqlCommand comm = new MySqlCommand("select * from usuarios
where email =@email and senha =@senha");

        comm.Parameters.Clear();
        comm.Parameters.Add("@email", MySqlDbType.VarChar, 50).Value =
txtemail.Text;
        comm.Parameters.Add("@senha", MySqlDbType.VarChar, 30).Value =
txtsenha.Text;
        comm.CommandType = CommandType.Text;
        MySqlDataReader dr;
        dr = comm.ExecuteReader();
        dr.Read();
        if (dr.HasRows)
        {
        Form3 formulario3 = new Form3();
        formulario3.ShowDialog();
        }
        }
        catch
        
        {
          MessageBox.Show("login errado");
        }
      }
      private void btncadastro_Click(object sender, EventArgs e)
      {
      Form2 formulario2 = new Form2();
      formulario2.ShowDialog();
      }
      private void btnsair_Click(object sender, EventArgs e)
      {
      Application.Exit();
      }
}
        
        Form2.cs

private void btncadastrar_Click(object sender, EventArgs e)
   {
    string strcon = "server = 127.0.0.1; user id = root; database =
    bdlogin";
    MySqlConnection cn = new MySqlConnection(strcon);
    cn.Open();
    MySqlCommand comm = new MySqlCommand();
    comm.Connection = cn;
    comm.CommandType = CommandType.Text;
    comm.CommandText = "insert into usuarios
    values('"+txtlogin.Text+"','"+txtpassword.Text+"')'";
    comm.ExecuteNonQuery();
    comm.Connection.Close();
    MessageBox.Show("Cadastro realizado com sucesso!!!");
  }