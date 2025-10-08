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


            if (Operacoes.Salvar(txt_origem_rota.Text, txt_destino_rota.Text, distancia))
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

        private void tool_sair_rotas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

/*
 
-----------------------------------------------
 Metodos 
-----------------------------------------------
 
 */


    public class Operacoes 
    {


        public static bool Salvar
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

       


    };

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

    public static bool CampoIDDesnecessario ( params TextBox[] campos)
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
        foreach (Control controle in controles)
        {
            if (controle is TextBox texto)
                texto.Clear();
            else if (controle is NumericUpDown numeric)
                numeric.Value = numeric.Minimum; // ou 0
        }
    }
}

