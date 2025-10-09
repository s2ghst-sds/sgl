using System.Data;
using System.Reflection.Metadata.Ecma335;
using MySql.Data.MySqlClient;

namespace sgl
{


    public partial class sglform : Form
    {



        public sglform()
        {
            InitializeComponent();
        }

        private void tool_save_rotas_Click(object sender, EventArgs e)
        {

            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.CamposEstaoVazios(txt_origem_rota, txt_destino_rota))
            {
                return;
            }
            //metodo de verificação de campo ID desnecessario
            if (ValidarCampos.CampoIDDesnecessario(txt_id_rota))
            {
                return;
            }

            //como usamos numeric, atribuimos a uma variavel decimal, para armazenar a distancia
            decimal distancia = num_distancia_rota.Value;

            // Validação adicional da distancia (se necessário):
            if (distancia <= 0)
            {
                MessageBox.Show("A distância deve ser maior que zero!");
                num_distancia_rota.Focus();
                return;
            }


            if (OperacoesRota.SalvarRota(txt_origem_rota.Text, txt_destino_rota.Text, distancia))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos(txt_origem_rota, txt_destino_rota, num_distancia_rota);

                MessageBox.Show("Salvo com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao salvar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }
        private void tool_editar_rotas_Click(object sender, EventArgs e)
        {
            if (ValidarCampos.CamposEstaoVazios(txt_origem_rota, txt_destino_rota))
            {
                return;
            }
            if (ValidarCampos.CampoIDNecessario(txt_id_rota))
            {
                return;
            }

            decimal distancia = num_distancia_rota.Value;

            // Validação adicional da distancia:
            if (distancia <= 0)
            {
                MessageBox.Show("A distância deve ser maior que zero!");
                num_distancia_rota.Focus();
                return;
            }

            if (OperacoesRota.EditarRota(txt_id_rota.Text, txt_origem_rota.Text, txt_destino_rota.Text, distancia))
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota);
                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao editar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }




        }

        private void tool_sair_rotas_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //no momento não existe tela de login para retornar ou "fechar" o sistema para validar outros usuarios.
        }

        private void tool_pesquisar_rotas_Click(object sender, EventArgs e)
        {
            //ideia principal é verificar o preenchimento do valor do id e caso haja id, fazer uma busca individual, caso não, busca de todas as rotas.
            //ou, podemos ver os campos preenchidos como filtros
            //dgv_rotas nome do datagridview

            /*verificar o id, caso tenha, busca com o metodo pré-definido de buscar e preencher os campos do professor,

            caso id não seja preenchido, e os campos sim, recebe os dados dos campos para fazer a consulta no sql.

            caso nenhums destes if's sejam acionados, faz a busca por completo. */

            if (!ValidarCampos.ValidacaoSemAviso(txt_id_rota))
            {

                OperacoesRota.ConsultarRota(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota);
                return;

                


            }
            if (txt_origem_rota.Text != "" || txt_destino_rota.Text != "" || num_distancia_rota.Value > 0)
            {
                OperacoesRota.ConsultarRotasLike(
                    dgv_rotas,
                    txt_origem_rota,
                    txt_destino_rota,
                    num_distancia_rota);
                return;
            }
            else
            {

                OperacoesRota.ConsultarRotas(dgv_rotas);
                return;
            }


        }

        private void tool_excluir_rotas_Click(object sender, EventArgs e)
        {
            
            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja excluir?",
            "Confirmação",
            MessageBoxButtons.YesNo
            );

            if (resultado != DialogResult.Yes)
            {
                OperacoesRota.ExcluirRota(txt_id_rota.Text);
                return;
            }

            return;



        }
    }

    /*

    -----------------------------------------------
     Metodos 
    -----------------------------------------------

     */


    public class OperacoesRota
    {


        public static bool SalvarRota
            (
            string origem,
            string destino,
            decimal distancia
            )


        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;



            try
            {
                using
                (conexao = new MySqlConnection("Server = localhost; Port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {
                    conexao.Open();

                    sql = "INSERT INTO rotas (origem, destino, distancia) VALUES(@ORIGEM, @DESTINO, @DISTANCIA)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ORIGEM", origem);
                    comando.Parameters.AddWithValue("@DESTINO", destino);
                    comando.Parameters.AddWithValue("@DISTANCIA", distancia);
                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar rota! " + ex.Message);
                return false;
            }
            finally
            {
            }

        }

        public static bool EditarRota
             (
             string id,
             string origem,
             string destino,
             decimal distancia
             )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;

            //if // metodo de verificação para campos necessarios, id necessario, obrigatorio destino ou origem ser preenchidos.




            try
            {
                using (conexao = new MySqlConnection("Server = localhost; Port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "UPDATE rotas" +
                        " SET origem = @ORIGEM, destino = @DESTINO, distancia = @DISTANCIA " +
                        "WHERE rotaID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@ORIGEM", origem);
                    comando.Parameters.AddWithValue("@DESTINO", destino);
                    comando.Parameters.AddWithValue("@DISTANCIA", distancia);

                    comando.ExecuteNonQuery();


                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Rota não encontrada! Verifique o id!");
                        //metodo de limpeza dos campos
                        return false;
                    }
                    else
                    {
                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }

        }

        public static bool ConsultarRota
            (TextBox txt_id_rota,
            TextBox txt_origem_rota, TextBox txt_destino_rota, NumericUpDown num_distancia_rota)
        {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("Server = localhost; Port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {
                    conexao.Open();
                    sql = "SELECT * FROM rotas WHERE rotaID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_rota.Text);
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        // Preencher os campos do formulário com os dados retornados
                        // Exemplo:
                        txt_origem_rota.Text = dr["origem"].ToString();
                        txt_destino_rota.Text = dr["destino"].ToString();
                        num_distancia_rota.Value = Convert.ToDecimal(dr["distancia"]);
                        return true; // Rota encontrada e campos preenchidos
                    }
                    else
                    {
                        MessageBox.Show("Rota não encontrada! Verifique o id!");
                        return false; // Rota não encontrada
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar rota! " + ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }


        }

        public static bool ConsultarRotas(DataGridView dgv_rotas)
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using(conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                { 
                    
                conexao.Open();


                sql = "SELECT *  FROM rotas";
                da = new MySqlDataAdapter(sql, conexao);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dgv_rotas.DataSource = dt;


                return true;
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao consultar rotas!" + ex.Message);
                return false;

            }

            finally
            {
            }

        }

        

        public static bool ConsultarRotasLike(
            DataGridView dgv_rotas,
            TextBox txt_origem_rota, TextBox txt_destino_rota, NumericUpDown num_distancia_rotas)
        {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;

            try
            {
                using (conexao = new MySqlConnection("server=localhost;port=3306;Database=sgl_sql;Uid=root;Pwd=;"))
                {
                    conexao.Open();

                    // SQL base
                    sql = "SELECT * FROM rotas WHERE 1=1";
                    comando = new MySqlCommand(sql, conexao);

                    // Adicionar filtros DINAMICAMENTE
                    if (!string.IsNullOrWhiteSpace(txt_origem_rota.Text))
                    {
                        sql += " AND origem LIKE @ORIGEM";
                        comando.Parameters.AddWithValue("@ORIGEM", $"%{txt_origem_rota.Text}%");
                    }

                    if (!string.IsNullOrWhiteSpace(txt_destino_rota.Text))
                    {
                        sql += " AND destino LIKE @DESTINO";
                        comando.Parameters.AddWithValue("@DESTINO", $"%{txt_destino_rota.Text}%");
                    }

                    if (num_distancia_rotas.Value > 0)
                    {
                        sql += " AND distancia >= @DISTANCIA";
                        comando.Parameters.AddWithValue("@DISTANCIA", num_distancia_rotas.Value);
                    }

                    // ATUALIZAR o comando com SQL final
                    comando.CommandText = sql;

                    // DataAdapter deve usar o COMANDO (com parâmetros)
                    using (da = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv_rotas.DataSource = dt;
                    }

                    return true;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;

            }

            finally
            {

            }


        }

        public static bool ExcluirRota(string id)
        {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;
            try
            {
                using (conexao = new MySqlConnection("Server = localhost; Port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {
                    conexao.Open();
                    sql = "DELETE FROM rotas WHERE rotaID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Rota não encontrada! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir rota! " + ex.Message);
                return false;
            }
            finally
            {
            }
        }


    }

    /*

    -----------------------------------------------
     Validação de campos
    -----------------------------------------------

     */



    public class ValidarCampos // validar campos da rota
        {

            public static bool CamposEstaoVazios(params TextBox[] campos)
            {
                foreach (TextBox campo in campos)
                {
                    if (string.IsNullOrWhiteSpace(campo.Text))
                    {
                        MessageBox.Show("O campo " + campo.Name + " deve ser preenchido!");
                        campo.Focus();
                        return true;
                    }

                }
                return false;
            }

            public static bool CampoIDDesnecessario(params TextBox[] campos)
            {
                foreach (TextBox campo in campos)
                {
                    if (!string.IsNullOrEmpty(campo.Text))
                    {
                        MessageBox.Show("O campo ID não deve ser preenchido!");
                        campo.Clear();
                        return true;
                    }
                }
                return false;
            }

            public static bool CampoIDNecessario(params TextBox[] campos)
            {
                foreach (TextBox campo in campos)
                {
                    if (string.IsNullOrEmpty(campo.Text))
                    {
                        MessageBox.Show("O campo ID  deve ser preenchido!");
                        campo.Clear();
                        return true;
                    }
                }
                return false;

            }

            // no warn validation, a validação precisa apenas validar se há preenchimento dos campos

            public static bool ValidacaoSemAviso
                (params Control[] controles)
            {
                foreach (Control controle in controles)
                {
                    if (controle is TextBox texto && string.IsNullOrWhiteSpace(texto.Text))
                    {
                        texto.Focus();
                        return true;
                    }
                    else if (controle is NumericUpDown numeric && numeric.Value <= 0)
                    {
                        numeric.Focus();
                        return true;
                    }
                }
                return false;

            }
        }

        /*

        -----------------------------------------------
         Metodos auxiliares
        -----------------------------------------------

         */

        public class Limpar
        {

            public static void LimparCampos(params Control[] controles)
            {
                {
                    foreach (Control controle in controles)
                    {
                        if (controle is TextBox texto)
                            texto.Clear();
                        else if (controle is NumericUpDown numeric)
                            numeric.Value = numeric.Minimum; // ou 0
                    }
                }
            }
        }
}


