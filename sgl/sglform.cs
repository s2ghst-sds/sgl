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
            Operacoes OpSalvar = new Operacoes();
            OpSalvar.Salvar(
                txt_origem_rota.Text,
                txt_destino_rota.Text,
                txt_distancia_rota.Text,
                txt_id_rota,
                txt_origem_rota,
                txt_destino_rota,
                txt_distancia_rota
            );
        }

        private void tool_sair_rotas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

    public class Operacoes
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string sql;

        public void Salvar
            (
            string origem,
            string destino,
            string distancia,
            TextBox txt_id_rota,
            TextBox txt_origem_rota,
            TextBox txt_destino_rota,
            TextBox txt_distancia_rota)
        {

            try
            {
                using
                (conexao = new MySqlConnection("Server = localhost; Port = 3306; Database = sgl_sgb; Uid = root; Pwd =;"))
                {

                    sql = "INSERT INTO clientes (origem, destino, distancia) VALUES(@ORIGEM, @DESTINO, @DISTANCIA)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", origem);
                    comando.Parameters.AddWithValue("@NOME", destino);
                    comando.Parameters.AddWithValue("@TELEFONE", distancia);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar rota! " + ex.Message);
            }
            finally
            {
                LimparCampos limpar = new LimparCampos();
                limpar.LimparCamposRota(txt_id_rota, txt_origem_rota, txt_destino_rota, txt_distancia_rota);
            }

        }


    };

    public abstract class Validar //validação d campos, classe abstrata base
    {

        public virtual void CamposSalvarRota(string origem, string destino, string distancia)
        {
            //vazio pq vou alterar nas classes derivadas
        }
        //desculpa mas ainda n entendi o sentido de polimorfismo aqui
    }



    public class ValidarRota : Validar // validar campos da rota
    {

        public override void CamposSalvarRota(string origem, string destino, string distancia) // metodo especifico para validação
        {
            if (string.IsNullOrEmpty(origem))
            {
                MessageBox.Show("O campo origem precisa ser preenchido!");
                return;
            }

            if (string.IsNullOrEmpty(destino))
            {
                MessageBox.Show("O campo destino precisa ser preenchido!");
                return;
            }

            if (string.IsNullOrEmpty(distancia))
            {
                MessageBox.Show("O campo distancia precisa ser preenchido!");
                return;
            }

        }
    }

    public class LimparCampos
    {
    
        public void LimparCamposRota(TextBox txt_id_rota, TextBox txt_origem_rota, TextBox txt_destino_rota, TextBox txt_distancia_rota)
        {
            txt_id_rota.Clear();
            txt_origem_rota.Clear();
            txt_destino_rota.Clear();
            txt_distancia_rota.Clear();
        }

    }





}
