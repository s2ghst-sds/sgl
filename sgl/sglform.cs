using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace sgl
{



    public partial class sglform : Form
    {
        public sglform()
        {
            InitializeComponent();
        }

        //proximas taks
        // incluir novo estado booleano de ativo ou não, para evitar a exclusão dos dados vinculados
        // tratar erro de exclus'ao de tabelas referenciadas, para informar o cliente a impossibilidade de exclus'ao
        // e informar a maneira de correta de desativar item vinculado

        //incrementar visual do programa incluindo tela de inicio e possivel altera;'ao de cores!

        //adicionar resultado de salvamento e edição com resultado no dgv?


        // infelixmente notamos que o sql não permite a exlusão de dados referenciados de tabelas relacionadas.
        // mesmo que a exclusão seja adaptada no codigo, dessa forma, futuramente encontraremos inconsistencias
        // na tabela referenciada (sendo estes lacunas dos dados excluidos)
        // podendo gerar descontentamentos do usuario final.
        // desta forma, sugerimos a inclusão de um campo "ativo" (booleano) para desativar o registro, ao invés de exclui-lo.

        /*

        -----------------------------------------------
            Rotas tools.
        -----------------------------------------------

        */


        private void tool_save_rotas_Click(object sender, EventArgs e)
        {

            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.ControlesVazios(txt_origem_rota, txt_destino_rota, cb_situacao_rota))
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


            if (OperacoesRota.SalvarRota(txt_origem_rota.Text, txt_destino_rota.Text, distancia, cb_situacao_rota.Text))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos(txt_origem_rota, txt_destino_rota, num_distancia_rota, cb_situacao_rota);

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
            if (ValidarCampos.ControlesVazios(txt_origem_rota, txt_destino_rota, cb_situacao_rota))
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

            if (OperacoesRota.EditarRota(txt_id_rota.Text, txt_origem_rota.Text, txt_destino_rota.Text, distancia, cb_situacao_rota.Text))
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota, cb_situacao_rota);
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
            this.Hide();
            LandingPage LandingPage = new LandingPage();
            LandingPage.Show();
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

            MessageBox.Show("A pesquisa pode ser feita por ID (preenchendo o campo ID), ou por filtros (preenchendo qualquer outro campo, exceto o ID). Caso nenhum campo seja preenchido, todas as rotas serão exibidas.");

            if (!ValidarCampos.ValidacaoSemAviso(txt_id_rota))
            {

                OperacoesRota.ConsultarRota(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota, cb_situacao_rota);
                return;




            }
            if (txt_origem_rota.Text != "" || txt_destino_rota.Text != "" || num_distancia_rota.Value > 0 || cb_situacao_rota.SelectedIndex != -1)
            {
                OperacoesRota.ConsultarRotasLike(
                    dgv_rotas,
                    txt_origem_rota,
                    txt_destino_rota,
                    num_distancia_rota,
                    cb_situacao_rota);
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

            if (resultado == DialogResult.Yes)
            {
                OperacoesRota.ExcluirRota(txt_id_rota.Text);
                Limpar.LimparCampos(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota, cb_situacao_rota);
                return;
            }

            return;



        }

        private void tool_vanish_rotas_Click(object sender, EventArgs e)
        {
            Limpar.LimparCampos(txt_id_rota, txt_origem_rota, txt_destino_rota, num_distancia_rota, cb_situacao_rota);

            MessageBox.Show("Campos limpos com sucesso!");
        }


        /*

        -----------------------------------------------
            Combustiveis tools.
        -----------------------------------------------

         */

        private void tool_sair_combustivel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage LandingPage = new LandingPage();
            LandingPage.Show();
            //still dont have the login form.
        }

        private void tool_salvar_combustivel_Click(object sender, EventArgs e)
        {
            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.ControlesVazios(cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel))
            {
                return;
            }
            //metodo de verificação de campo ID desnecessario
            if (ValidarCampos.CampoIDDesnecessario(txt_id_combustivel))
            {
                return;
            }

            //como usamos numeric, atribuimos a uma variavel decimal, para armazenar a distancia

            if (OperacoesCombustivel.SalvarCombustivel(cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos(cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel);

                MessageBox.Show("Salvo com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao salvar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_editar_combustivel_Click(object sender, EventArgs e)
        {

            if (ValidarCampos.ControlesVazios(cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel))
            {
                return;
            }
            if (ValidarCampos.CampoIDNecessario(txt_id_combustivel))
            {
                return;
            }


            if (OperacoesCombustivel.EditarCombustivel(txt_id_combustivel, cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel))
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos(txt_id_combustivel, cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel);
                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao editar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }
        }

        private void tool_pesquisar_combustivel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A pesquisa pode ser feita por ID (preenchendo o campo ID), ou por filtros (preenchendo qualquer outro campo, exceto o ID). Caso nenhum campo seja preenchido, todas as rotas serão exibidas.");


            if (!ValidarCampos.ValidacaoSemAviso(txt_id_combustivel))
            {

                OperacoesCombustivel.ConsultarCombustivel(txt_id_combustivel, cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel);
                return;




            }
            if (cb_tipo_combustivel.Text != "" || num_preco_combustivel.Value > 0 || dtp_consulta_combustivel.Text != "1753/01/01")
            {
                OperacoesCombustivel.ConsultarCombustivelLike(
                    dgv_combustivel,
                    cb_tipo_combustivel,
                    num_preco_combustivel,
                    dtp_consulta_combustivel
                    );
                return;
            }
            else
            {

                OperacoesCombustivel.ConsultarCombustiveis(dgv_combustivel);
                return;

            }


        }

        private void tool_excluir_combustivel_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja excluir?",
            "Confirmação",
            MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                OperacoesCombustivel.ExcluirCombustivel(txt_id_combustivel);
                Limpar.LimparCampos(txt_id_combustivel, cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel);

                return;
            }

            return;

        }

        private void tool_vanish_combustivel_Click(object sender, EventArgs e)
        {
            Limpar.LimparCampos(txt_id_combustivel, cb_tipo_combustivel, num_preco_combustivel, dtp_consulta_combustivel);

            MessageBox.Show("Campos limpos com sucesso!");

        }

        /*

        -----------------------------------------------
        Viagens Tools 
        -----------------------------------------------

        */


        private void tool_exiticon_viagens_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage LandingPage = new LandingPage();
            LandingPage.Show();
        }

        private void tool_salvar_viagens_Click(object sender, EventArgs e)
        {
            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.ControlesVazios
                (
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                )
                )
            {
                return;
            }
            //metodo de verificação de campo ID desnecessario
            if (ValidarCampos.CampoIDDesnecessario(txt_id_viagem))
            {
                return;
            }

            //como usamos numeric, atribuimos a uma variavel decimal, para armazenar a distancia

            if (OperacoesViagem.SalvarViagem
                (
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                ))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos
                    (
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                    );

                MessageBox.Show("Salvo com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao salvar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_editar_viagem_Click(object sender, EventArgs e)
        {
            if (ValidarCampos.CampoIDNecessario(txt_id_viagem))
            {
                return;
            }
            if (ValidarCampos.ControlesVazios
                   (
                   txt_veiculo_viagem,
                   txt_motorista_viagem,
                   txt_rota_viagem,
                   dtp_saida_viagem,
                   dtp_chegada_viagem,
                   cb_situacao_viagem
                   )
                   )
            {
                return;
            }

            if (OperacoesViagem.EditarViagem
                (
                txt_id_viagem,
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                )
                )
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos
                (
                txt_id_viagem,
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                );
                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao editar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_search_viagens_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A pesquisa pode ser feita por ID (preenchendo o campo ID), ou por filtros (preenchendo qualquer outro campo, exceto o ID). Caso nenhum campo seja preenchido, todas as rotas serão exibidas.");


            if (!ValidarCampos.ValidacaoSemAviso(txt_id_viagem))
            {
                OperacoesViagem.ConsultarViagem
                    (
                   txt_id_viagem,
                   txt_veiculo_viagem,
                   txt_motorista_viagem,
                   txt_rota_viagem,
                   dtp_saida_viagem,
                   dtp_chegada_viagem,
                   cb_situacao_viagem
                    );
                return;
            }
            if (
                   txt_veiculo_viagem.Text != ""
                || txt_motorista_viagem.Text != ""
                || txt_rota_viagem.Text != ""
                || dtp_saida_viagem.Text != "1753/01/01"
                || dtp_chegada_viagem.Text != "1753/01/01"
                || cb_situacao_viagem.Text != ""
                )
            {
                OperacoesViagem.ConsultarViagemLike(
                   dgv_viagem,
                   txt_veiculo_viagem,
                   txt_motorista_viagem,
                   txt_rota_viagem,
                   dtp_saida_viagem,
                   dtp_chegada_viagem,
                   cb_situacao_viagem
                    );
                return;
            }
            else
            {

                OperacoesViagem.ConsultarViagens(dgv_viagem);
                return;

            }


        }

        private void tool_trash_viagens_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja excluir?",
            "Confirmação",
            MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                OperacoesViagem.ExcluirViagem(txt_id_viagem.Text);
                Limpar.LimparCampos
                (
                txt_id_viagem,
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                );

                return;
            }

            return;

        }

        private void tool_vanish_viagem_Click(object sender, EventArgs e)
        {
            Limpar.LimparCampos
                (
                txt_id_viagem,
                txt_veiculo_viagem,
                txt_motorista_viagem,
                txt_rota_viagem,
                dtp_saida_viagem,
                dtp_chegada_viagem,
                cb_situacao_viagem
                );

            MessageBox.Show("Campos limpos com sucesso!");

        }

        /*

        -----------------------------------------------
            Veiculos Tools. 
        -----------------------------------------------

        */


        private void tool_sair_veiculos_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage LandingPage = new LandingPage();
            LandingPage.Show();
        }

        private void tool_save_veiculos_Click(object sender, EventArgs e)
        {
            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.ControlesVazios(txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo))
            {
                return;
            }
            //metodo de verificação de campo ID desnecessario
            if (ValidarCampos.CampoIDDesnecessario(txt_id_veiculo))
            {
                return;
            }

            //como usamos numeric, atribuimos a uma variavel decimal, para armazenar a distancia

            if (OperacoesVeiculo.SalvarVeiculo(txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos(txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo);

                MessageBox.Show("Salvo com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao salvar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_editar_veiculos_Click(object sender, EventArgs e)
        {

            if (ValidarCampos.CampoIDNecessario(txt_id_veiculo))
            {
                return;
            }

            if (ValidarCampos.ControlesVazios(txt_id_veiculo, txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo))
            {
                return;
            }


            if (OperacoesVeiculo.EditarVeiculo(txt_id_veiculo, txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo))
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos(txt_id_veiculo, txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo);
                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao editar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_pesquisar_veiculos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A pesquisa pode ser feita por ID (preenchendo o campo ID), ou por filtros (preenchendo qualquer outro campo, exceto o ID). Caso nenhum campo seja preenchido, todas as rotas serão exibidas.");


            if (!ValidarCampos.ValidacaoSemAviso(txt_id_veiculo))
            {

                OperacoesVeiculo.ConsultarVeiculo(txt_id_veiculo, txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo);
                return;

            }
            if (txt_modelo_veiculo.Text != "" || txt_placa_veiculo.Text != "" || num_consumo_veiculo.Value > 0 || num_cargamax_veiculo.Value > 0 || cb_situacao_veiculo.SelectedIndex != -1)
            {
                OperacoesVeiculo.ConsultarVeiculoLike
                    (
                    dgv_veiculos,
                    txt_modelo_veiculo,
                    txt_placa_veiculo,
                    num_consumo_veiculo,
                    num_cargamax_veiculo,
                    cb_situacao_veiculo
                    );
                return;
            }
            else
            {

                OperacoesVeiculo.ConsultarVeiculos(dgv_veiculos);
                return;

            }

        }

        private void tool_excluir_veiculos_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja excluir?",
            "Confirmação",
            MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                OperacoesVeiculo.ExcluirVeiculo(txt_id_veiculo);
                Limpar.LimparCampos(txt_id_veiculo, txt_modelo_veiculo, txt_placa_veiculo, num_consumo_veiculo, num_cargamax_veiculo, cb_situacao_veiculo);
                return;
            }

            return;

        }

        private void tool_vanish_veiculo_Click(object sender, EventArgs e)
        {

            Limpar.LimparCampos
            (
            txt_id_veiculo,
            txt_modelo_veiculo,
            txt_placa_veiculo,
            num_consumo_veiculo,
            num_cargamax_veiculo,
            cb_situacao_veiculo
            );


            MessageBox.Show("Campos limpos com sucesso!");

        }

        /*

        -----------------------------------------------
             Motorista Tools. 
        -----------------------------------------------
        
        */


        private void tool_sair_motoristas_Click(object sender, EventArgs e)
        {
            this.Hide();
            LandingPage LandingPage = new LandingPage();
            LandingPage.Show();
        }

        private void tool_salvar_motoristas_Click(object sender, EventArgs e)
        {
            if (ValidarCampos.CampoIDDesnecessario(txt_id_motorista))
            {
                return;
            }

            //chamamos o metodo de verificação de campos vazios
            if (ValidarCampos.ControlesVazios
                (
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                ))
            {
                return;
            }

            if (OperacoesMotorista.SalvarMotorista
                (
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                ))
            {
                // Só limpa se salvou com SUCESSO
                Limpar.LimparCampos
                (
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                );

                MessageBox.Show("Salvo com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao salvar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_editar_motoristas_Click(object sender, EventArgs e)
        {
            if (ValidarCampos.CampoIDNecessario(txt_id_motorista))
            {
                return;
            }
            if (ValidarCampos.ControlesVazios
                (
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                ))
            {
                return;
            }

            if (OperacoesMotorista.EditarMotorista
                (
                txt_id_motorista,
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                ))
            {
                // Só limpa se editou com SUCESSO
                Limpar.LimparCampos
                (
                txt_id_motorista,
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                );

                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                // Mantém os dados preenchidos para o usuário corrigir
                MessageBox.Show("Erro ao editar! Verifique os dados.");
                // Campos NÃO são limpos - usuário pode tentar novamente
            }

        }

        private void tool_pesquisar_motoristas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A pesquisa pode ser feita por ID (preenchendo o campo ID), ou por filtros (preenchendo qualquer outro campo, exceto o ID). Caso nenhum campo seja preenchido, todas as rotas serão exibidas.");


            if (!ValidarCampos.ValidacaoSemAviso(txt_id_motorista))
            {

                OperacoesMotorista.ConsultarMotorista
                (
                txt_id_motorista,
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                );
                return;




            }
            if (txt_nome_motorista.Text != "" || txt_cnh_motorista.Text != "" || txt_telefone_motorista.Text != "")
            {
                OperacoesMotorista.ConsultarMotoristaLike(
                    dgv_motorista,
                    txt_id_motorista,
                    txt_nome_motorista,
                    txt_cnh_motorista,
                    txt_telefone_motorista,
                    cb_situacao_motorista
                    );
                return;
            }
            else
            {

                OperacoesMotorista.ConsultarMotoristas(dgv_motorista);
                return;
            }


        }

        private void tool_excluir_motoristas_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "Tem certeza que deseja excluir?",
            "Confirmação",
            MessageBoxButtons.YesNo
            );

            if (resultado == DialogResult.Yes)
            {
                OperacoesMotorista.ExcluirMotorista(txt_id_motorista.Text);
                Limpar.LimparCampos
                (
                txt_id_motorista,
                txt_nome_motorista,
                txt_cnh_motorista,
                txt_telefone_motorista,
                cb_situacao_motorista
                );

                return;
            }

            return;


        }

        private void tool_vanish_motorista_Click(object sender, EventArgs e)
        {
            Limpar.LimparCampos
            (
            txt_id_motorista,
            txt_nome_motorista,
            txt_cnh_motorista,
            txt_telefone_motorista,
            cb_situacao_motorista
            );

            MessageBox.Show("Campos limpos com sucesso!");


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
            decimal distancia,
            string situacao
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

                    sql = "INSERT INTO rota (origem, destino, distancia, situacao) VALUES(@ORIGEM, @DESTINO, @DISTANCIA, @SITUACAO)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ORIGEM", origem);
                    comando.Parameters.AddWithValue("@DESTINO", destino);
                    comando.Parameters.AddWithValue("@DISTANCIA", distancia);
                    comando.Parameters.AddWithValue("@SITUACAO", situacao);

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
             decimal distancia,
             string situacao
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


                    sql = "UPDATE rota" +
                        " SET origem = @ORIGEM, destino = @DESTINO, distancia = @DISTANCIA, situacao = @SITUACAO " +
                        "WHERE rotaID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@ORIGEM", origem);
                    comando.Parameters.AddWithValue("@DESTINO", destino);
                    comando.Parameters.AddWithValue("@DISTANCIA", distancia);
                    comando.Parameters.AddWithValue("@SITUACAO", situacao);


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
            (
            TextBox txt_id_rota,
            TextBox txt_origem_rota,
            TextBox txt_destino_rota,
            NumericUpDown num_distancia_rota,
            ComboBox cb_situacao_rota
            )
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
                    sql = "SELECT * FROM rota WHERE rotaID = @ID";
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
                        cb_situacao_rota.Text = dr["situacao"].ToString();
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

        public static bool ConsultarRotas
            (
            DataGridView dgv_rotas
            )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "SELECT *  FROM rota";
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



        public static bool ConsultarRotasLike
            (
            DataGridView dgv_rotas,
            TextBox txt_origem_rota,
            TextBox txt_destino_rota,
            NumericUpDown num_distancia_rotas,
            ComboBox cb_situacao_rota
            )
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
                    sql = "SELECT * FROM rota WHERE 1=1";
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

                    if (cb_situacao_rota.SelectedIndex != -1)
                    {
                        sql += " AND situacao = @SITUACAO";
                        comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_rota.Text);
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

        public static bool ExcluirRota
            (
            string id
            )
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
                    sql = "DELETE FROM rota WHERE rotaID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Rota não encontrada! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Rota excluída com sucesso!");
                        return true;
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Código do erro de foreign key constraint
            {
                MessageBox.Show("Não é possível excluir!\n\nExistem viagens associadas a ela no sistema.\nA rota será mantida para preservar o histórico.\n" +
                    "Sugerimos que edite a situação do mesmo!");
                return false;
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
            Combustivel
    -----------------------------------------------

     */

    public class OperacoesCombustivel
    {

        public static bool SalvarCombustivel
        (
        ComboBox cb_tipo_combustivel,
        NumericUpDown num_preco_combustivel,
        DateTimePicker dtp_consulta_combustivel
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

                    sql = "INSERT INTO preco_combustivel (combustivel, preco, data_consulta) VALUES(@COMBUSTIVEL, @PRECO, @DATA_CONSULTA)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@COMBUSTIVEL", cb_tipo_combustivel.Text);
                    comando.Parameters.AddWithValue("@PRECO", num_preco_combustivel.Value);
                    comando.Parameters.AddWithValue("@DATA_CONSULTA", dtp_consulta_combustivel.Value.ToString("yyyy-MM-dd"));
                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar Combustivel! " + ex.Message);
                return false;
            }
            finally
            {
            }

        }

        public static bool EditarCombustivel
            (
            TextBox txt_id_combustivel,
            ComboBox cb_tipo_combustivel,
            NumericUpDown num_preco_combustivel,
            DateTimePicker dtp_consulta_combustivel
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


                    sql = "UPDATE preco_combustivel" +
                        " SET combustivel = @COMBUSTIVEL, preco = @PRECO, data_consulta = @DATA_CONSULTA " +
                        "WHERE precoID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_combustivel.Text);
                    comando.Parameters.AddWithValue("@COMBUSTIVEL", cb_tipo_combustivel.Text);
                    comando.Parameters.AddWithValue("@PRECO", num_preco_combustivel.Value);
                    comando.Parameters.AddWithValue("@DATA_CONSULTA", dtp_consulta_combustivel.Value.ToString("yyyy-MM-dd"));

                    comando.ExecuteNonQuery();


                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Combustivel não encontrado! Verifique o id!");
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

        public static bool ConsultarCombustivel
            (
            TextBox txt_id_combustivel,
            ComboBox cb_tipo_combustivel,
            NumericUpDown num_preco_combustivel,
            DateTimePicker dtp_consulta_combustivel
            )
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
                    sql = "SELECT * FROM preco_combustivel WHERE precoID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_combustivel.Text);
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        // Preencher os campos do formulário com os dados retornados
                        // Exemplo:
                        cb_tipo_combustivel.Text = dr["combustivel"].ToString();
                        num_preco_combustivel.Value = Convert.ToDecimal(dr["preco"]);
                        dtp_consulta_combustivel.Value = Convert.ToDateTime(dr["data_consulta"]);
                        return true; // Rota encontrada e campos preenchidos
                    }
                    else
                    {
                        MessageBox.Show("Combustivel não encontrado! Verifique o id!");
                        return false; // Rota não encontrada
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar combustivel! " + ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }


        }

        public static bool ConsultarCombustivelLike
                        (
            DataGridView dgv_combustivel,
            ComboBox cb_tipo_combustivel,
            NumericUpDown num_preco_combustivel,
            DateTimePicker dtp_consuta_combustivel
            )
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
                    sql = "SELECT * FROM preco_combustivel WHERE 1=1";
                    comando = new MySqlCommand(sql, conexao);

                    // Adicionar filtros DINAMICAMENTE
                    if (!string.IsNullOrWhiteSpace(cb_tipo_combustivel.Text))
                    {
                        sql += " AND combustivel LIKE @COMBUSTIVEL";
                        comando.Parameters.AddWithValue("@COMBUSTIVEL", $"%{cb_tipo_combustivel.Text}%");
                    }

                    if (num_preco_combustivel.Value != 0)
                    {
                        sql += " AND preco LIKE @PRECO";
                        comando.Parameters.AddWithValue("@PRECO", $"%{num_preco_combustivel.Value}%");
                    }

                    if (dtp_consuta_combustivel.Value != new DateTime(1753, 01, 01))
                    {
                        sql += " AND data_consulta LIKE @DATA_CONSULTA";
                        comando.Parameters.AddWithValue("@DATA_CONSULTA", dtp_consuta_combustivel.Value);
                    }

                    // ATUALIZAR o comando com SQL final
                    comando.CommandText = sql;

                    // DataAdapter deve usar o COMANDO (com parâmetros)
                    using (da = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv_combustivel.DataSource = dt;
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

        public static bool ConsultarCombustiveis
            (
            DataGridView dgv_combustivel
            )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "SELECT *  FROM preco_combustivel";
                    da = new MySqlDataAdapter(sql, conexao);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgv_combustivel.DataSource = dt;


                    return true;
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao consultar combustiveis!" + ex.Message);
                return false;

            }

            finally
            {
            }

        }

        public static bool ExcluirCombustivel
            (TextBox txt_id_combustivel)
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
                    sql = "DELETE FROM preco_combustivel WHERE precoID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_combustivel.Text);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Combustivel não encontrado! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Combustivel excluído com sucesso!");

                        return true;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir combustivel! " + ex.Message);
                return false;
            }
            finally
            {
            }
        }

    }

    /*

    -----------------------------------------------
            Operacoes Viagem
    -----------------------------------------------

     */


    public class OperacoesViagem
    {

        public static bool SalvarViagem
        (
        TextBox txt_veiculo_viagem,
        TextBox txt_motorista_viagem,
        TextBox txt_rota_viagem,
        DateTimePicker dtp_saida_viagem,
        DateTimePicker dtp_chegada_viagem,
        ComboBox cb_situacao_viagem
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

                    sql = "INSERT INTO viagem (veiculoID, motoristaID, rotaID, data_saida, data_chegada, situacao)" +
                        " VALUES(@VEICULOID, @MOTORISTAID, @ROTAID, @DATA_SAIDA, @DATA_CHEGADA, @SITUACAO)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@VEICULOID", txt_veiculo_viagem.Text);
                    comando.Parameters.AddWithValue("@MOTORISTAID", txt_motorista_viagem.Text);
                    comando.Parameters.AddWithValue("@ROTAID", txt_rota_viagem.Text);
                    comando.Parameters.AddWithValue("@DATA_SAIDA", dtp_saida_viagem.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@DATA_CHEGADA", dtp_chegada_viagem.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_viagem.Text);

                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar viagem! " + ex.Message);
                return false;
            }
            finally
            {
            }

        }

        public static bool EditarViagem
            (
            TextBox txt_id_viagem,
            TextBox txt_veiculo_viagem,
            TextBox txt_motorista_viagem,
            TextBox txt_rota_viagem,
            DateTimePicker dtp_saida_viagem,
            DateTimePicker dtp_chegada_viagem,
            ComboBox cb_situacao_viagem
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


                    sql = "UPDATE viagem" +
                        " SET veiculoID = @VEICULOID, motoristaID = @MOTORISTAID, rotaID = @ROTAID, " +
                        " data_saida = @DATA_SAIDA, data_chegada = @DATA_CHEGADA, situacao = @SITUACAO " +
                        " WHERE viagemID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_viagem.Text);
                    comando.Parameters.AddWithValue("@VEICULOID", txt_veiculo_viagem.Text);
                    comando.Parameters.AddWithValue("@MOTORISTAID", txt_motorista_viagem.Text);
                    comando.Parameters.AddWithValue("@ROTAID", txt_rota_viagem.Text);
                    comando.Parameters.AddWithValue("@DATA_SAIDA", dtp_saida_viagem.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@DATA_CHEGADA", dtp_chegada_viagem.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_viagem.Text);

                    comando.ExecuteNonQuery();


                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Viagem não encontrada! Verifique o id!");
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

        public static bool ConsultarViagem
            (
            TextBox txt_id_viagem,
            TextBox txt_veiculo_viagem,
            TextBox txt_motorista_viagem,
            TextBox txt_rota_viagem,
            DateTimePicker dtp_saida_viagem,
            DateTimePicker dtp_chegada_viagem,
            ComboBox cb_situacao_viagem
            )
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
                    sql = "SELECT * FROM viagem WHERE viagemID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_viagem.Text);
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        // Preencher os campos do formulário com os dados retornados
                        // Exemplo:
                        txt_id_viagem.Text = dr["viagemID"].ToString();
                        txt_veiculo_viagem.Text = dr["veiculoID"].ToString();
                        txt_motorista_viagem.Text = dr["motoristaID"].ToString();
                        txt_rota_viagem.Text = dr["rotaID"].ToString();
                        dtp_saida_viagem.Value = Convert.ToDateTime(dr["data_saida"]);
                        dtp_chegada_viagem.Value = Convert.ToDateTime(dr["data_chegada"]);
                        cb_situacao_viagem.Text = dr["situacao"].ToString();

                        return true; // Rota encontrada e campos preenchidos
                    }
                    else
                    {
                        MessageBox.Show("Viagem não encontrada! Verifique o id!");
                        return false; // Rota não encontrada
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar viagem! " + ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }


        }

        public static bool ConsultarViagemLike
            (
            DataGridView dgv_viagem,
            TextBox txt_veiculo_viagem,
            TextBox txt_motorista_viagem,
            TextBox txt_rota_viagem,
            DateTimePicker dtp_saida_viagem,
            DateTimePicker dtp_chegada_viagem,
            ComboBox cb_situacao_viagem
            )
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
                    sql = "SELECT * FROM viagem WHERE 1=1";
                    comando = new MySqlCommand(sql, conexao);
                    // Adicionar filtros DINAMICAMENTE
                    if (!string.IsNullOrWhiteSpace(txt_veiculo_viagem.Text))
                    {
                        sql += " AND veiculoID LIKE @VEICULOID";
                        comando.Parameters.AddWithValue("@VEICULOID", $"%{txt_veiculo_viagem.Text}%");
                    }
                    if (!string.IsNullOrWhiteSpace(txt_motorista_viagem.Text))
                    {
                        sql += " AND motoristaID LIKE @MOTORISTAID";
                        comando.Parameters.AddWithValue("@MOTORISTAID", $"%{txt_motorista_viagem.Text}%");
                    }
                    if (!string.IsNullOrWhiteSpace(txt_rota_viagem.Text))
                    {
                        sql += " AND rotaID LIKE @ROTAID";
                        comando.Parameters.AddWithValue("@ROTAID", $"%{txt_rota_viagem.Text}%");
                    }
                    if (dtp_saida_viagem.Value != new DateTime(1753, 01, 01))
                    {
                        sql += " AND data_saida = @DATA_SAIDA";
                        comando.Parameters.AddWithValue("@DATA_SAIDA", dtp_saida_viagem.Value.ToString("yyyy-MM-dd"));
                    }
                    if (dtp_chegada_viagem.Value != new DateTime(1753, 01, 01))
                    {
                        sql += " AND data_chegada = @DATA_CHEGADA";
                        comando.Parameters.AddWithValue("@DATA_CHEGADA", dtp_chegada_viagem.Value.ToString("yyyy-MM-dd"));
                    }
                    if (!string.IsNullOrWhiteSpace(cb_situacao_viagem.Text))
                    {
                        sql += " AND situacao LIKE @SITUACAO";
                        comando.Parameters.AddWithValue("@SITUACAO", $"%{cb_situacao_viagem.Text}%");
                    }

                    // ATUALIZAR o comando com SQL final
                    comando.CommandText = sql;

                    // DataAdapter deve usar o COMANDO (com parâmetros)
                    using (da = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv_viagem.DataSource = dt;
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

        public static bool ConsultarViagens
            (
            DataGridView dgv_viagem
            )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "SELECT *  FROM viagem";
                    da = new MySqlDataAdapter(sql, conexao);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgv_viagem.DataSource = dt;


                    return true;
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao consultar viagens!" + ex.Message);
                return false;

            }

            finally
            {
            }

        }

        public static bool ExcluirViagem
            (
            string id
            )
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
                    sql = "DELETE FROM viagem WHERE viagemID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Viagem não encontrada! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Viagem excluída com sucesso!");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir viagem! " + ex.Message);
                return false;
            }
            finally
            {
            }
        }





    }

    /*

    -----------------------------------------------
        Operacoes Veiculos
    -----------------------------------------------

    */


    public class OperacoesVeiculo
    {

        public static bool SalvarVeiculo
        (
        TextBox txt_modelo_veiculo,
        TextBox txt_placa_veiculo,
        NumericUpDown num_consumo_veiculo,
        NumericUpDown num_cargamax_veiculo,
        ComboBox cb_situacao_veiculo
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

                    sql = "INSERT INTO veiculo (modelo, placa, consumo_medio, carga_maxima, situacao) VALUES(@MODELO, @PLACA, @CONSUMO_MEDIO, @CARGA_MAXIMA, @SITUACAO)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@MODELO", txt_modelo_veiculo.Text);
                    comando.Parameters.AddWithValue("@PLACA", txt_placa_veiculo.Text);
                    comando.Parameters.AddWithValue("@CONSUMO_MEDIO", num_consumo_veiculo.Value);
                    comando.Parameters.AddWithValue("@CARGA_MAXIMA", num_cargamax_veiculo.Value);
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_veiculo.Text);
                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar veiculo! " + ex.Message);
                return false;
            }
            finally
            {
            }

        }

        public static bool EditarVeiculo
            (
            TextBox txt_id_veiculos,
            TextBox txt_modelo_veiculo,
            TextBox txt_placa_veiculo,
            NumericUpDown num_consumo_veiculo,
            NumericUpDown num_cargamax_veiculo,
            ComboBox cb_situacao_veiculo
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


                    sql = "UPDATE veiculo" +
                        " SET modelo = @MODELO, placa = @PLACA, consumo_medio = @CONSUMO_MEDIO, carga_maxima = @CARGA_MAXIMA," +
                        " situacao = @SITUACAO " +
                        " WHERE veiculoID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_veiculos.Text);
                    comando.Parameters.AddWithValue("@MODELO", txt_modelo_veiculo.Text);
                    comando.Parameters.AddWithValue("@PLACA", txt_placa_veiculo.Text);
                    comando.Parameters.AddWithValue("@CONSUMO_MEDIO", num_consumo_veiculo.Value);
                    comando.Parameters.AddWithValue("@CARGA_MAXIMA", num_cargamax_veiculo.Value);
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_veiculo.Text);

                    comando.ExecuteNonQuery();


                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Veiculo não encontrado! Verifique o id!");
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

        public static bool ConsultarVeiculo
            (
            TextBox txt_id_veiculo,
            TextBox txt_modelo_veiculo,
            TextBox txt_placa_veiculo,
            NumericUpDown num_consumo_veiculo,
            NumericUpDown num_cargamax_veiculo,
            ComboBox cb_situacao_veiculo
            )
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
                    sql = "SELECT * FROM veiculo WHERE veiculoID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_veiculo.Text);
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        // Preencher os campos do formulário com os dados retornados
                        // Exemplo:
                        txt_modelo_veiculo.Text = dr["modelo"].ToString();
                        txt_placa_veiculo.Text = dr["placa"].ToString();
                        num_consumo_veiculo.Value = Convert.ToDecimal(dr["consumo_medio"]);
                        num_cargamax_veiculo.Value = Convert.ToDecimal(dr["carga_maxima"]);
                        cb_situacao_veiculo.Text = dr["situacao"].ToString();

                        return true; // Rota encontrada e campos preenchidos
                    }
                    else
                    {
                        MessageBox.Show("Veiculo não encontrado! Verifique o id!");
                        return false; // Rota não encontrada
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar veiculo! " + ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }


        }

        public static bool ConsultarVeiculoLike
            (
            DataGridView dgv_veiculos,
            TextBox txt_modelo_veiculo,
            TextBox txt_placa_veiculo,
            NumericUpDown num_consumo_veiculo,
            NumericUpDown num_cargamax_veiculo,
            ComboBox cb_situacao_veiculo
            )
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
                    sql = "SELECT * FROM veiculo WHERE 1=1";
                    comando = new MySqlCommand(sql, conexao);

                    // Adicionar filtros DINAMICAMENTE
                    if (!string.IsNullOrWhiteSpace(txt_modelo_veiculo.Text))
                    {
                        sql += " AND modelo LIKE @MODELO";
                        comando.Parameters.AddWithValue("@MODELO", $"%{txt_modelo_veiculo.Text}%");
                    }

                    if (!string.IsNullOrWhiteSpace(txt_placa_veiculo.Text))
                    {
                        sql += " AND placa LIKE @PLACA";
                        comando.Parameters.AddWithValue("@PLACA", $"%{txt_placa_veiculo.Text}%");
                    }


                    if (num_consumo_veiculo.Value != 0)
                    {
                        sql += " AND consumo_medio LIKE @CONSUMO_MEDIO";
                        comando.Parameters.AddWithValue("@CONSUMO_MEDIO", $"%{num_consumo_veiculo.Value}%");
                    }
                    if (num_cargamax_veiculo.Value != 0)
                    {
                        sql += " AND carga_maxima LIKE @CARGA_MAXIMA";
                        comando.Parameters.AddWithValue("@CARGA_MAXIMA", $"%{num_cargamax_veiculo.Value}%");
                    }
                    if (cb_situacao_veiculo.SelectedIndex != -1)
                    {
                        sql += " AND situacao = @SITUACAO";
                        comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_veiculo.Text);
                    }




                    // ATUALIZAR o comando com SQL final
                    comando.CommandText = sql;

                    // DataAdapter deve usar o COMANDO (com parâmetros)
                    using (da = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv_veiculos.DataSource = dt;
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

        public static bool ConsultarVeiculos
            (
            DataGridView dgv_veiculos
            )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "SELECT *  FROM veiculo";
                    da = new MySqlDataAdapter(sql, conexao);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgv_veiculos.DataSource = dt;


                    return true;
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao consultar veiculos!" + ex.Message);
                return false;

            }

            finally
            {
            }

        }

        public static bool ExcluirVeiculo
            (
            TextBox txt_id_veiculo
            )
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
                    sql = "DELETE FROM veiculo WHERE veiculoID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_veiculo.Text);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Veiculo não encontrada! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Veiculo excluído com sucesso!");
                        return true;

                    }
                }

            }
            catch (MySqlException ex) when (ex.Number == 1451) // Código do erro de foreign key constraint
            {
                MessageBox.Show("Não é possível excluir!\n\nExistem viagens associadas a ela no sistema.\nA rota será mantida para preservar o histórico.\n" +
                    "Sugerimos que edite a situação do mesmo!");
                return false;

                // Opcional: Focar em algum campo ou fazer alguma ação específica
                // txtbx_idRota.Text = "";
                // txtbx_idRota.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir veiculo! " + ex.Message);
                return false;
            }
            finally
            {
            }
        }

    }

    /*

    -----------------------------------------------
    Operacoes Motorista
    -----------------------------------------------

    */


    public class OperacoesMotorista
    {

        public static bool SalvarMotorista
        (
            TextBox txt_nome_motorista,
            TextBox txt_cnh_motorista,
            TextBox txt_telefone_motorista,
            ComboBox cb_situacao_motorista
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

                    sql = "INSERT INTO motorista (nome, cnh, telefone, situacao) VALUES(@NOME, @CNH, @TELEFONE, @SITUACAO)";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@NOME", txt_nome_motorista.Text);
                    comando.Parameters.AddWithValue("@CNH", txt_cnh_motorista.Text);
                    comando.Parameters.AddWithValue("@TELEFONE", txt_telefone_motorista.Text);
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_motorista.Text);

                    comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar motorista! " + ex.Message);
                return false;
            }
            finally
            {
            }

        }

        public static bool EditarMotorista
        (
            TextBox txt_id_motorista,
            TextBox txt_nome_motorista,
            TextBox txt_cnh_motorista,
            TextBox txt_telefone_motorista,
            ComboBox cb_situacao_motorista
        )
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


                    sql = "UPDATE motorista" +
                        " SET nome = @NOME, cnh = @CNH, telefone = @TELEFONE, situacao = @SITUACAO" +
                        " WHERE motoristaID = @ID";


                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_motorista.Text);
                    comando.Parameters.AddWithValue("@NOME", txt_nome_motorista.Text);
                    comando.Parameters.AddWithValue("@CNH", txt_cnh_motorista.Text);
                    comando.Parameters.AddWithValue("@TELEFONE", txt_telefone_motorista.Text);
                    comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_motorista.Text);

                    comando.ExecuteNonQuery();


                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Motorista não encontrada! Verifique o id!");
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

        public static bool ConsultarMotorista
            (
            TextBox txt_id_motorista,
            TextBox txt_nome_motorista,
            TextBox txt_cnh_motorista,
            TextBox txt_telefone_motorista,
            ComboBox cb_situacao_motorista

            )
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
                    sql = "SELECT * FROM motorista WHERE motoristaID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", txt_id_motorista.Text);
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        // Preencher os campos do formulário com os dados retornados
                        // Exemplo:
                        txt_nome_motorista.Text = dr["nome"].ToString();
                        txt_cnh_motorista.Text = dr["cnh"].ToString();
                        txt_telefone_motorista.Text = dr["telefone"].ToString();
                        cb_situacao_motorista.Text = dr["situacao"].ToString();
                        return true; // Rota encontrada e campos preenchidos
                    }
                    else
                    {
                        MessageBox.Show("Motorista não encontrado! Verifique o id!");
                        return false; // Rota não encontrada
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar motorista! " + ex.Message);
                return false;
            }
            finally
            {
                // deixaremos vazio pois temos metodos de conclusão fora do deste metodo, para validar a conclusão do mesmo.
            }


        }

        public static bool ConsultarMotoristaLike
        (
            DataGridView dgv_motorista,
            TextBox txt_id_motorista,
            TextBox txt_nome_motorista,
            TextBox txt_cnh_motorista,
            TextBox txt_telefone_motorista,
            ComboBox cb_situacao_motorista
        )
        {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            string sql;

            try
            {
                using (conexao = new MySqlConnection("server=localhost;port=3306;Database=sgl_sql;Uid=root;Pwd=;"))
                {
                    conexao.Open();

                    // SQL base
                    sql = "SELECT * FROM motorista WHERE 1=1";
                    comando = new MySqlCommand(sql, conexao);

                    // Adicionar filtros DINAMICAMENTE
                    if (!string.IsNullOrWhiteSpace(txt_nome_motorista.Text))
                    {
                        sql += " AND nome LIKE @NOME";
                        comando.Parameters.AddWithValue("@NOME", $"%{txt_nome_motorista.Text}%");
                    }

                    if (!string.IsNullOrWhiteSpace(txt_cnh_motorista.Text))
                    {
                        sql += " AND cnh LIKE @CNH";
                        comando.Parameters.AddWithValue("@CNH", $"%{txt_cnh_motorista.Text}%");
                    }

                    if (!string.IsNullOrWhiteSpace(txt_telefone_motorista.Text))
                    {
                        sql += " AND telefone LIKE @TELEFONE";
                        comando.Parameters.AddWithValue("@TELEFONE", $"%{txt_telefone_motorista.Text}%");
                    }

                    if (cb_situacao_motorista.SelectedIndex != -1)
                    {
                        sql += " AND situacao = @SITUACAO";
                        comando.Parameters.AddWithValue("@SITUACAO", cb_situacao_motorista.Text);
                    }



                    // ATUALIZAR o comando com SQL final
                    comando.CommandText = sql;

                    // DataAdapter deve usar o COMANDO (com parâmetros)
                    using (da = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv_motorista.DataSource = dt;
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

        public static bool ConsultarMotoristas
        (
        DataGridView dgv_motorista
        )
        {

            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataAdapter da;
            MySqlDataReader dr;
            string sql;


            try
            {
                using (conexao = new MySqlConnection("server = localhost; port = 3306; Database = sgl_sql; Uid = root; Pwd =;"))
                {

                    conexao.Open();


                    sql = "SELECT *  FROM motorista";
                    da = new MySqlDataAdapter(sql, conexao);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgv_motorista.DataSource = dt;


                    return true;
                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show("Erro ao consultar motoristas!" + ex.Message);
                return false;

            }

            finally
            {
            }

        }


        public static bool ExcluirMotorista
        (
        string id
        )
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
                    sql = "DELETE FROM motorista WHERE motoristaID = @ID";
                    comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("@ID", id);
                    if (comando.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Motorista não encontrado! Verifique o id!");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Motorista excluído com sucesso!");

                        return true;
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Código do erro de foreign key constraint
            {
                MessageBox.Show("Não é possível excluir!\n\nExistem viagens associadas a ela no sistema.\nA rota será mantida para preservar o histórico.\n" +
                    "Sugerimos que edite a situação do mesmo!");
                return false;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir motorista! " + ex.Message);
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
                    campo.Focus();
                    return true;
                }
            }
            return false;

        }

        public static bool ControlesVazios(params Control[] controles)
        {
            foreach (Control controle in controles)
            {
                if (controle is TextBox texto && string.IsNullOrWhiteSpace(texto.Text))
                {
                    MessageBox.Show("O campo " + texto.Name + " deve ser preenchido!");
                    texto.Focus();
                    return true;
                }
                if (controle is NumericUpDown numeric && numeric.Value <= 0)
                {
                    MessageBox.Show("O campo " + numeric.Name + " deve ser maior que zero!");
                    numeric.Focus();
                    return true;
                }
                if (controle is ComboBox combo && combo.SelectedIndex == -1)
                {
                    MessageBox.Show("O campo " + combo.Name + " deve ser selecionado!");
                    combo.Focus();
                    return true;
                }
                if (controle is DateTimePicker dateTimePicker && dateTimePicker.Value == new DateTime(1753, 01, 01))
                {
                    MessageBox.Show("O campo " + dateTimePicker.Name + " deve ser alterado para o dia da operação!");
                    dateTimePicker.Focus();
                    return true;
                }

            }

            return false;
        }

        public static bool ValidacaoSemAviso(params Control[] controles)
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
                    if (controle is NumericUpDown numeric)
                        numeric.Value = numeric.Minimum; // ou 0
                    if (controle is ComboBox combo)
                        combo.SelectedIndex = -1;
                    if (controle is DateTimePicker dtp)
                        dtp.Value = new DateTime(1753, 01, 01);
                }
            }
        }
    }
}


